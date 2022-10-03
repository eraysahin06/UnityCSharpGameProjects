using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    [SerializeField] List<QuestionItem> questionList;
    [SerializeField] TMP_Text questionTxt;

    [SerializeField] GameObject answerPrefab;
    [SerializeField] Transform answerContainer;


    int whichQuestion;
    int questionQty;

    string[] choices = { "A)", "B)", "C)" };

    GameManager GameManager;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        questionList = questionList.OrderBy(i=>Random.value).ToList();
        //PrintQuestions();
    }

    public void PrintQuestions()
    {
        questionQty = 0;
        questionTxt.text = questionList[whichQuestion].question;

        questionTxt.GetComponent<CanvasGroup>().alpha = 0f;
        questionTxt.GetComponent<RectTransform>().localScale = Vector3.zero;
        CreateAnswers();
    }

    void CreateAnswers()
    {

        GameObject[] answersToDelete = GameObject.FindGameObjectsWithTag("answerTag");

        if(answersToDelete.Length>=0)
        {
            for (int i = 0; i < answersToDelete.Length; i++)
            {
                DestroyImmediate(answersToDelete[i]);
            }
        }


        for (int i = 0; i < 3; i++)
        {
            GameObject answerObject = Instantiate(answerPrefab);
            answerObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[i];
            answerObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = questionList[whichQuestion].answers[i].ToString();
            answerObject.transform.SetParent(answerContainer);
            answerObject.GetComponent<Transform>().localScale = Vector3.zero;
        }

        GameManager.correctAnswer = questionList[whichQuestion].correctAnswer;

        StartCoroutine(OpenAnswers());
    }

    IEnumerator OpenAnswers()
    {
        yield return new WaitForSeconds(.5f);

        questionTxt.GetComponent<CanvasGroup>().DOFade(1, .3f);
        questionTxt.GetComponent<RectTransform>().DOScale(1, .3f);

        yield return new WaitForSeconds(.4f);

        while(questionQty < 3)
        {
            answerContainer.GetChild(questionQty).DOScale(1, .2f);
            yield return new WaitForSeconds(.2f);
            questionQty++;
        }
        whichQuestion++;
        GameManager.questGetsAnswered = true;
    }
}
