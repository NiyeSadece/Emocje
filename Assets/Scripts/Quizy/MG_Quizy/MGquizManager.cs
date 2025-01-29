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
    private bool quizFinished = false; // Flaga oznaczaj¹ca zakoñczenie quizu

    void Start()
    {
        currentQuestionIndex = 0;
        score = 0; // Inicjalizacja punktów
        DisplayQuestion();
    }

    void Update()
    {
        // SprawdŸ, czy quiz siê zakoñczy³ i czeka na wciœniêcie spacji
        if (quizFinished && Input.GetKeyDown(KeyCode.Space))
        {
            LoadMainMenu();
        }
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            // Logika zakoñczenia quizu
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
        score++; // Zwiêkszenie punktów za poprawn¹ odpowiedŸ
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void WrongAnswer()
    {
        // Tutaj mo¿na dodaæ logikê na wypadek b³êdnej odpowiedzi
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void FinishQuiz()
    {
        questionText.text = "Quiz zakoñczony. Twój wynik: " + score + "/" + questions.Count + "\nNaciœnij spacjê, aby wróciæ do menu g³ównego.";
        foreach (Button btn in answerButtons)
        {
            btn.gameObject.SetActive(false);
        }

        // Ustaw flagê zakoñczenia quizu
        quizFinished = true;
    }

    private void LoadMainMenu()
    {
       
            SceneManager.LoadScene(1);
        
    }
}
