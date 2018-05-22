using Assets.Libs.Engine.Providers;
using Assets.Libs.Logic.Interfaces.Engine;
using Assets.Libs.Logic.Interfaces.Managers;
using Assets.Libs.Logic.Interfaces.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Animator))]
public class ActionView : MonoBehaviour, IActionView
{
    const float TimeAwait = 1.55f;

    int _oldPlayerScore = 0;
    int _oldAiScore = 0;
    Text _actionText;
    Animator _animator;
    void Awake()
    {
        _actionText = GetComponent<Text>();
        _animator = GetComponent<Animator>();

        ILoggerManager logger = FindObjectOfType<GameManagerProvider>() as ILoggerManager;
        logger.OnRoundLog += (RoundResultType roundResult, StepType firstPlayerStep, StepType secondPlayerStep, int firstScore, int secondScore) =>
        {
            StartCoroutine(ShowActionText(secondPlayerStep.ToString(), roundResult.ToString(), firstScore, secondScore));
        };
    }

    public void ShowAction(string enemyResult, string roundResult, int newPlayerScore, int newAiScore)
    {
        StartCoroutine(ShowActionText(enemyResult, roundResult, newPlayerScore, newAiScore));
    }

    IEnumerator ShowActionText(string enemyResult, string roundResult, int newPlayerScore, int newAiScore)
    {
        _animator.SetTrigger("Show");
        _actionText.text = enemyResult;
        yield return new WaitForSeconds(TimeAwait);

        _animator.SetTrigger("Show");
        _actionText.text = roundResult;
        yield return new WaitForSeconds(TimeAwait);

        _animator.SetTrigger("Show");
        _actionText.text = $"{_oldPlayerScore}:{_oldAiScore} -> {newPlayerScore}:{newAiScore}";
        _oldPlayerScore = newPlayerScore;
        _oldAiScore = newAiScore;
        yield return new WaitForSeconds(TimeAwait);
        _actionText.text = string.Empty;
    }

}
