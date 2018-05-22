using Assets.Libs.Engine.Providers;
using Assets.Libs.Logic.Interfaces.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreView : MonoBehaviour
{
    Text _scoreText;

    void Awake()
    {
        _scoreText = GetComponent<Text>();
        IScoreProvider _scoreProvider = FindObjectOfType<GameManagerProvider>() as IScoreProvider;
        if (_scoreProvider != null)
        {
            _scoreProvider.OnScoreUpdate += (int firstScore, int secondScore) =>
            {
                _scoreText.text = $"{firstScore}:{secondScore}";
            };
        }
    }
}
