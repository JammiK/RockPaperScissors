using AssemblyCSharp.Assets.Libs.Logic.Managers;
using Assets.Libs.Logic.Interfaces.Engine;
using Assets.Libs.Logic.Interfaces.Managers;
using Assets.Libs.Logic.Interfaces.Player;
using Assets.Libs.Logic.Managers;
using Assets.Libs.Logic.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Libs.Engine.Providers
{
    class GameManagerProvider : MonoBehaviour, IGameManagerProvider, IScoreProvider, ILoggerManager
    {
        public event ScoreUpdateHandler OnScoreUpdate;
        public event OnRoundFinishLog OnRoundLog;

        AiPlayerType _aiPlayerType;

        [Range(0.0f, 1.0f)]
        [SerializeField]
        float _chanceWin;

        IGameManager _gameManager;
        IPlayerInput _inputManagerPlayer;

        IPlayer _human;
        IPlayer _aiPlayer;

        IActionView _acitionView;

        bool _isPause = false;

        void Awake()
        {
            _inputManagerPlayer = new PlayerInputManager();
            _human = new Player(_inputManagerPlayer);
			InitAiInputManager();
            InitGameManager();
            _acitionView = FindObjectOfType<ActionView>() as IActionView;
        }

        /// <summary>
        /// Registers the rock from button
        /// </summary>
        public void RegisterRock()
        {
            if (_isPause)
            {
                return;
            }
            _inputManagerPlayer.RegisterRock();
            ResolveRound();
        }

        /// <summary>
        /// Registers the paper from button
        /// </summary>
        public void RegisterPaper()
        {
            if (_isPause)
            {
                return;
            }
            _inputManagerPlayer.RegisterPaper();
            ResolveRound();
        }

        /// <summary>
        /// Registers the scissors from button
        /// </summary>
        public void RegisterScissors()
        {
            if (_isPause)
            {
                return;
            }
            _inputManagerPlayer.RegisterScissors();
            ResolveRound();
        }


        /// <summary>
        /// Resolves the round and update results
        /// </summary>
        void ResolveRound()
        {
            _gameManager.ResolveRound();
            StartCoroutine(BlockButtons());

            int humanScore = _gameManager.Human.Score;
            int aiScore = _gameManager.AIPlayer.Score;
            StepType humanStep = _gameManager.Human.LastStep;
            StepType aiStep = _gameManager.AIPlayer.LastStep;

            OnScoreUpdate?.Invoke(humanScore, aiScore);
            OnRoundLog?.Invoke(_gameManager.LastRoundResult, _gameManager.Human.LastStep, _gameManager.AIPlayer.LastStep, humanScore, aiScore);
        }

        /// <summary>
        /// Coroutine for pause while showing result of round
        /// </summary>
        IEnumerator BlockButtons()
        {
            _isPause = true;
            yield return new WaitForSeconds(1.55f * 3);
            _isPause = false;
        }

        /// <summary>
        /// Sets the honest ai from inspector button
        /// </summary>
        public void SetHonestAi()
        {
            _aiPlayerType = AiPlayerType.Honest;
            InitAiInputManager();
            InitGameManager();
        }

        /// <summary>
        /// Sets the cheater ai from inspector button
        /// </summary>
        public void SetCheaterAi()
        {
            _aiPlayerType = AiPlayerType.Cheater;
            InitAiInputManager();
            InitGameManager();

        }

        void InitGameManager()
        {
            _gameManager = new GameManager(_human, _aiPlayer);
            OnScoreUpdate?.Invoke(_gameManager.Human.Score, _gameManager.AIPlayer.Score);
        }

        void InitAiInputManager() {
            if (_aiPlayerType == AiPlayerType.Honest)
            {
                _aiPlayer = new Player(new HonestAiInputManager());
            }
            else
            {
                _aiPlayer = new Player(new CheatInputManager(_human, _chanceWin));
            }
        }
    }

    [CustomEditor(typeof(GameManagerProvider))]
    public class GameManagerProviderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameManagerProvider provider = (GameManagerProvider)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Honest AI"))
            {
                provider.SetHonestAi();
            }
            if (GUILayout.Button("Cheater AI"))
            {
                provider.SetCheaterAi();
            }
            GUILayout.EndHorizontal();
        }
    }
}
