using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    public GameObject PostTestPANEL;
    public GameObject GameOverPANEL;

    public Color startColor;

    public GameObject trueButton;
    public GameObject falseButton;

    public Text ScoreTXT;

    int totalQuestions = 0;
    public int score;

    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;


    [SerializeField]
    private float timeBetweenQuestions = 1f;

    private bool Clicked = false;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    void Start ()
    {
       
        GameOverPANEL.SetActive(false);

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            totalQuestions = unansweredQuestions.Count;
        }

        SetCurrentQuestion();     
    }

    public void retry (){
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver (){
        if (SceneManager.GetActiveScene().buildIndex == 13) {
            GameOverPANEL.SetActive(true);
            PostTestPANEL.SetActive(false);
            ScoreTXT.text = score + "/" + totalQuestions;
            StartCoroutine(WaitForCompletion());
        } else {
             GameOverPANEL.SetActive(true);
             PostTestPANEL.SetActive(false);
             ScoreTXT.text = score + "/" + totalQuestions;
             PlayerPrefs.SetInt("levelAt", levelToUnlock);
        }
   
    }

    void GameComplete ()
    {
        SceneManager.LoadScene("Game Completed");
    }

    void SetCurrentQuestion()
    {
        if (unansweredQuestions.Count > 0)
        {
            int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            factText.text = currentQuestion.fact;

        } else{
            Debug.Log("Out Of Questions!");
            GameOver();
            } 
    }

    IEnumerator WaitForCompletion()
    {
        yield return new WaitForSeconds(3);
        GameComplete();
    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredQuestions.Remove (currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        SetCurrentQuestion ();
        Clicked = false;
        falseButton.GetComponent<Image>().color = Color.white;
        trueButton.GetComponent<Image>().color = Color.white;
    }

    public void UserSelectTrue ()
    {

       if (!Clicked)
       {
           Clicked = true;
           if (currentQuestion.isTrue)
           {
                trueButton.GetComponent<Image>().color = Color.green;
                score += 1;
            Debug.Log("CORRECTT!!!");
            trueAnswerText.text = "CORRECT!!!";
            falseAnswerText.text = "WRONG!!!";
           } else
           {
                trueButton.GetComponent<Image>().color = Color.red;
                Debug.Log("WRONG!");
            trueAnswerText.text = "WRONG!!!";
            falseAnswerText.text = "CORRECT!!!";
           }
       }
        
            StartCoroutine(TransitionToNextQuestion());
    }  
    
    public void UserSelectFalse ()
    {
        

       if (!Clicked)
       {
           Clicked = true;
           if (!currentQuestion.isTrue)
           {
                falseButton.GetComponent<Image>().color = Color.green;
                score += 1;
            Debug.Log("CORRECTT!!!");
            trueAnswerText.text = "CORRECT!!!";
            falseAnswerText.text = "WRONG!!!";
           } else
           {
                falseButton.GetComponent<Image>().color = Color.red;
                Debug.Log("WRONG!");
            trueAnswerText.text = "WRONG!!!";
            falseAnswerText.text = "CORRECT!!!";
           }
       }
        
            StartCoroutine(TransitionToNextQuestion());
    }
}
