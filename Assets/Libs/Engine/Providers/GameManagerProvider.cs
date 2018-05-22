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

        [SerializeField]
        AiPlayerType _aiPlayerType;

        [Range(0.0f, 1.0f)]
        [SerializeField]
        float _chanceWin;

        IGameManager _gameManager;
        IInput _inputManager;
        IActionView _acitionView;

        bool _isPause = false;

        void Awake()
        {
            _inputManager = new InputManager();
            IPlayer human = new HumanPlayer(_inputManager);
            IPlayer aiPlayer;
            if (_aiPlayerType == AiPlayerType.Honest)
            {
                aiPlayer = new AiPlayer();
            }
            else
            {
                aiPlayer = new CheatAiPlayer(_inputManager, _chanceWin);
            }
            _gameManager = new GameManager(human, aiPlayer);
            _acitionView = FindObjectOfType<ActionView>() as IActionView;
        }

        public void RegisterRock()
        {
            if (_isPause)
            {
                return;
            }
            _inputManager.RegisterRock();
            ResolveRound();
        }

        public void RegisterPaper()
        {
            if (_isPause)
            {
                return;
            }
            _inputManager.RegisterPaper();
            ResolveRound();
        }

        public void RegisterScissors()
        {
            if (_isPause)
            {
                return;
            }
            _inputManager.RegisterScissors();
            ResolveRound();
        }

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

        IEnumerator BlockButtons()
        {
            _isPause = true;
            yield return new WaitForSeconds(1.55f * 3);
            _isPause = false;
        }

        public void SetHonestAi()
        {
            _aiPlayerType = AiPlayerType.Honest;
            IPlayer aiPlayer = new AiPlayer();
        }

        public void SetCheaterAi()
        {
            _aiPlayerType = AiPlayerType.Cheater;
            IPlayer aiPlayer = new CheatAiPlayer(_inputManager, _chanceWin);
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
