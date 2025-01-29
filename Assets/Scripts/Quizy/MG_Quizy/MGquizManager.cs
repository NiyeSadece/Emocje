using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MGquizManager : MonoBehaviour
{

    public TMP_Text questionText;
    public TMP_Text scoreText;
    public Button[] answerButtons;

    public List<Question> questions;
    private int currentQuestionIndex;
    private int score; 
    private bool quizFinished = false; // Flaga oznaczaj�ca zako�czenie quizu

    void Start()
    {
        currentQuestionIndex = 0;
        score = 0; // Inicjalizacja punkt�w
        DisplayQuestion();
    }

    void Update()
    {
        // Sprawd�, czy quiz si� zako�czy� i czeka na wci�ni�cie spacji
        if (quizFinished && Input.GetKeyDown(KeyCode.Space))
        {
            LoadMainMenu();
        }
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            // Logika zako�czenia quizu
            FinishQuiz();
            return;
        }

        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
            answerButtons[i].onClick.RemoveAllListeners();

            if (i == currentQuestion.correctAnswerIndex)
            {
                answerButtons[i].onClick.AddListener(CorrectAnswer);
            }
            else
            {
                answerButtons[i].onClick.AddListener(WrongAnswer);
            }
        }
    }

    void CorrectAnswer()
    {
        score++; // Zwi�kszenie punkt�w za poprawn� odpowied�
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void WrongAnswer()
    {
        // Tutaj mo�na doda� logik� na wypadek b��dnej odpowiedzi
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void FinishQuiz()
    {
        questionText.text = "Quiz zako�czony. Tw�j wynik: " + score + "/" + questions.Count + "\nNaci�nij spacj�, aby wr�ci� do menu g��wnego.";
        foreach (Button btn in answerButtons)
        {
            btn.gameObject.SetActive(false);
        }

        // Ustaw flag� zako�czenia quizu
        quizFinished = true;
    }

    private void LoadMainMenu()
    {
       
            SceneManager.LoadScene(1);
        
    }
}
