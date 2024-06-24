using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TriviaGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] Button[] answerButtons;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Image[] livesImages;
    [SerializeField] Button startButton;
    [SerializeField] Canvas hideCanvas;
    [SerializeField] Image timeBar;
    [SerializeField] TextMeshProUGUI correctAnswersText;
    [SerializeField] int congratulationScene;
    [SerializeField] int loseScene;

    private int lives = 3;
    private int questionsAnswered = 0;
    private float timeLeft = 10f;
    private bool isGameOver = false;
    private bool gameStarted = false;
    private bool isGameWin = false;

    private List<Question> questions = new List<Question>();
    private Question currentQuestion;

    void Start()
    {
        LoadQuestions();
        SetUIActive(false);
        startButton.onClick.AddListener(StartGame);
        UpdateCorrectAnswersText();
    }

    void Update()
    {
        if (!gameStarted || isGameOver) return;

        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.Round(timeLeft).ToString();
        timeBar.fillAmount = timeLeft / 10f;

        if (timeLeft <= 0)
        {
            LoseLife();
        }
    }

    void LoadQuestions()
    {
        questions.Add(new Question("How often should you brush your teeth each day?", new string[] { "Twice", "Once" }, 0));
        questions.Add(new Question("What is the main cause of cavities?", new string[] { "Vegetables", "Bacteria" }, 1));
        questions.Add(new Question("At what age do children usually start losing their baby teeth?", new string[] { "6-7", "3-4" }, 0));
        questions.Add(new Question("What type of teeth are used for chewing food?", new string[] { "Incisors", "Molars" }, 1));
        questions.Add(new Question("Which part of the tooth is visible in your mouth?", new string[] { "Root", "Crown" }, 1));
        questions.Add(new Question("What should you use to clean between your teeth?", new string[] { "Floss", "Cotton swabs" }, 0));
        questions.Add(new Question("What vitamin is important for strong teeth and bones?", new string[] { "Vitamin D", "Vitamin C" }, 0));
        questions.Add(new Question("What is the main purpose of incisors?", new string[] { "Cutting food", "Grinding food" }, 0));
        questions.Add(new Question("What is another name for baby teeth?", new string[] { "Secondary teeth", "Primary teeth" }, 1));
        questions.Add(new Question("What can happen if you do not brush and floss regularly?", new string[] { "Cavities", "Stronger teeth" }, 0));
        questions.Add(new Question("What is the best drink for healthy teeth?", new string[] { "Soda", "Water" }, 1));
        questions.Add(new Question("How often should you visit the dentist for a check-up?", new string[] { "Twice a year", "Once a month" }, 0));
        questions.Add(new Question("What should you do after eating sugary snacks to help prevent cavities?", new string[] { "Drink more juice", "Brush your teeth" }, 1));
    }

    void StartGame()
    {
        gameStarted = true;
        SetUIActive(true);
        DisplayNextQuestion();
        hideCanvas.gameObject.SetActive(false);
    }

    void SetUIActive(bool isActive)
    {
        questionText.gameObject.SetActive(isActive);
        timerText.gameObject.SetActive(isActive);
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(isActive);
        }
        foreach (Image image in livesImages)
        {
            image.gameObject.SetActive(isActive);
        }
    }

    void DisplayNextQuestion()
    {
        if (questions.Count == 0)
        {
            GameOver();
            return;
        }

        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        questions.RemoveAt(index);

        questionText.text = currentQuestion.question;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
            int answerIndex = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(answerIndex));
        }

        timeLeft = 10f;
    }

    void CheckAnswer(int index)
    {
        if (index == currentQuestion.correctAnswerIndex)
        {
            questionsAnswered++;
            UpdateCorrectAnswersText();
            if (questionsAnswered == 3)
            {
                isGameWin = true;
                GameOver();
            }
            else
            {
                DisplayNextQuestion();
            }
        }
        else
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        lives--;
        livesImages[lives].color = Color.black;
        if (lives == 0)
        {
            isGameWin = false;
            GameOver();
        }
        else
        {
            DisplayNextQuestion();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        if(isGameWin) 
        {
            SceneManager.LoadScene(congratulationScene);
        }
        else 
        { 
            SceneManager.LoadScene(loseScene); 
        }
        isGameWin = false;
    }

    void UpdateCorrectAnswersText()
    {
        correctAnswersText.text = "Correct Answers: " + questionsAnswered;
    }

    public void ResetTriviaGame()
    {
        gameStarted = false;
        isGameOver = false;
        isGameWin = false;
        lives = 3;
        questionsAnswered = 0;
        timeLeft = 10f;

        SetUIActive(false);
        hideCanvas.gameObject.SetActive(true);
        UpdateCorrectAnswersText(); 
        
        foreach (Image lifeImage in livesImages)
        {
            lifeImage.color = Color.white;
        }
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;

    public Question(string question, string[] answers, int correctAnswerIndex)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
    }
}
