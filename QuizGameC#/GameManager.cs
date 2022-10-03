using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject questionPanel;
    [SerializeField] GameObject trueIcon, falseIcon;
    public bool questGetsAnswered;
    public string correctAnswer;
    QuestionManager questionManager;
    PlayerMoveManager moveManager;

    [SerializeField] GameObject robot_1, robot_2, robot_3;

    [SerializeField] GameObject correctResult, incorrectResult;

    SoundManager soundManager;

    int remainingRight;
    int correctAmount;
    private void Awake()
    {
        moveManager = Object.FindObjectOfType<PlayerMoveManager>();
        questionManager = Object.FindObjectOfType<QuestionManager>();
        soundManager = Object.FindObjectOfType<SoundManager>();
    }
    private void Start()
    {
        remainingRight = 3;
        correctAmount = 0;
        StartCoroutine(OpenGameRoutine());
    }
    IEnumerator OpenGameRoutine()
    {
        yield return new WaitForSeconds(.1f);
        soundManager.PlayStartSound();
        questionPanel.GetComponent<RectTransform>().DOAnchorPosX(30, 1f);

        yield return new WaitForSeconds(1.1f);
        questionManager.PrintQuestions();
    }




    public void CheckAnswer(string givenAnswer)
    {
        if(givenAnswer == correctAnswer)
        {
            correctAmount++;
            soundManager.PlayCorrectSound();
            if(correctAmount >= 15)
            {
                showCorrectResult();
            }
            else
            {
                questionManager.PrintQuestions();
            }
            SetActiveTrueIcon();
        }
        else
        {
            soundManager.PlayIncorrectSound();
            SetActiveFalseIcon();
            StartCoroutine(PlayerMistakenCameBack());
        }
    }

    void SetActiveTrueIcon()
    {
        trueIcon.GetComponent<CanvasGroup>().DOFade(1, .3f);

        Invoke("SetPassiveTrueIcon", .8f);
    }
    
    void SetActiveFalseIcon()
    {
        falseIcon.GetComponent<CanvasGroup>().DOFade(1, .3f);
        Invoke("SetPassiveFalseIcon", .8f);
    }

    void SetPassiveTrueIcon()
    {
        trueIcon.GetComponent<CanvasGroup>().DOFade(0, .3f);
    }

    void SetPassiveFalseIcon()
    {
        falseIcon.GetComponent<CanvasGroup>().DOFade(0, .3f);
    }

    IEnumerator PlayerMistakenCameBack()
    {
        yield return new WaitForSeconds(1f);

        moveManager.playerFalseAnswered();

        yield return new WaitForSeconds(1.4f);

        remainingRight--;

        LoseRight();

        if(remainingRight > 0)
        {
            moveManager.PlayerComeBack();

            yield return new WaitForSeconds(1f);

            questionManager.PrintQuestions();
        }
        else
        {
            showIncorrectResult();
        }

    }

    void LoseRight()
    {
        if(remainingRight == 2)
        {
           robot_3.SetActive(false);
           robot_2.SetActive(true);
           robot_1.SetActive(true);
        }
        else if(remainingRight == 1)
        {
           robot_3.SetActive(false);
           robot_2.SetActive(false);
           robot_1.SetActive(true);
        }
        else if (remainingRight == 0)
        {
            robot_3.SetActive(false);
            robot_2.SetActive(false);
            robot_1.SetActive(false);
        }

    }

    void showCorrectResult()
    {
        soundManager.PlayFinishSound();
        questionPanel.GetComponent<RectTransform>().DOAnchorPosX(-1100, 1f);
        correctResult.GetComponent<CanvasGroup>().DOFade(1, .5f);
        correctResult.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }
    void showIncorrectResult()
    {
        soundManager.PlayFinishSound();
        questionPanel.GetComponent<RectTransform>().DOAnchorPosX(-1100, 1f);
        incorrectResult.GetComponent<CanvasGroup>().DOFade(1, .5f);
        incorrectResult.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }

}
