using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Question_UI : MonoBehaviour
{
    public GameObject questionPanel;
    public Player player;

    // public List<Slot_UI> slots = new List<Slot_UI>();
    public TextMeshProUGUI QuestionNumber;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI answerA;
    public TextMeshProUGUI answerB;
    public TextMeshProUGUI answerC;
    public TextMeshProUGUI answerD;

    public Question[] questions;
    public Answer[] answers;
    public int questionNumber = 0;
    public int attemptTime = 0;
    public int score = 0;
    public int completed = 0;

    private DialogueManager dialoguePanel;
    private Task_UI_Empty taskPanel;
    private Task_UI taskPanel2;
    private Task_UI_Collection_Question taskPanel3;
    private Inventory_UI inventoryPanel;

    public bool questionUIActive = false;

    void Start()
    {
        questionPanel.SetActive(false);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     ToggleQuestion();
        // }
    }

    public void ToggleQuestion()
    {
        if (!questionPanel.activeSelf)
        {
            questionPanel.SetActive(true);
            questionUIActive = true;
            Setup();
        }
        else
        {
            questionUIActive = false;
            questionPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Setup()
    {
        QuestionNumber.text = (questionNumber + 1).ToString();
        Question.text = questions[questionNumber].question;
        answerA.text = answers[questionNumber].A;
        answerB.text = answers[questionNumber].B;
        answerC.text = answers[questionNumber].C;
        answerD.text = answers[questionNumber].D;
    }

    public void CheckCorrect(int answer)
    {
        UnityEngine.Debug.Log("questionNumber" + questionNumber+"  "+answer+"  "+answers[questionNumber].CorrectAnwser);
        if(completed ==0){
        if (answer == answers[questionNumber].CorrectAnwser)
        {
            score += 1;
            UnityEngine.Debug.Log(score+"score +1");
        }}
        NextQuestion();
    }

    public void NextQuestion()
    {
        if (completed == 0)
        {
            if (questionNumber < questions.Length - 1)
            {
                questionNumber += 1;
                Setup();
            }
            else
            {
                ShowScore();
            }
        }
        else
        {
            attemptTime += 1;
            completed = 0;
            UnityEngine.Debug.Log(score+"score!!!!!");
            UnityEngine.Debug.Log(questionNumber+"questionNumber!!!!!");
            if (score >= questionNumber + 1)
            {
                UnityEngine.Debug.Log("win" + score);
                questionNumber = 0;
                score = 0;
                SceneManager.LoadScene(5, LoadSceneMode.Single);
            }
            else
            {
                UnityEngine.Debug.Log("lose" + score);
                questionNumber = 0;
                score = 0;
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    SceneManager.LoadScene(6, LoadSceneMode.Single);
                }
            }
            ToggleQuestion();
        }
    }

    public void ShowScore()
    {
        completed = 1;
        QuestionNumber.text = "Final result";
        if (score == questionNumber + 1)
        {
            Question.text =
                "Great job! You have answered all the questions correctly. I can tell that you have the knowledge and skills of a real Angami soldier. \nCongratulations on your success!\nAs of now, there is some ongoing construction on the road leading to Sophuno's house. \nIn the meantime, feel free to explore our tribe and get to know more about our traditions and customs. \nChat with the warrior to learn more!";
            answerA.text = "Great!";
            answerB.text = "OKAY!";
            answerC.text = "Cannot wait to see her house!";
            answerD.text = "Thank you!";
        }
        else
        {
            Question.text =
                "Hey there, it's great to hear that you did a good job on the task. \nHowever, to pass the task with a full mark, you still need to put in some more effort and work hard. \nKeep practicing and learning, and I'm confident that you'll be able to achieve your goals. Good luck!";
            answerA.text = "Well, well...";
            answerB.text = "I will come back!";
            answerC.text = "So much new knowledge...";
            answerD.text = "I look forward to the challenge!";
        }
    }
}

[System.Serializable]
public class Question
{
    public string question;
}

[System.Serializable]
public class Answer
{
    public string A;
    public string B;
    public string C;
    public string D;
    public int CorrectAnwser;
}
