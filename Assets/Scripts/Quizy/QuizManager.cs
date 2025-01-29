using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text scoreText; // Dodaj nowy element tekstowy do wy�wietlania punkt�w
    public Button[] answerButtons;

    public List<Question> questions;
    private int currentQuestionIndex;
    private int score; // Zmienna do przechowywania punkt�w
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
            LoadNextLevel();
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
        questionText.text = "Quiz zako�czony. Tw�j wynik: " + score + "/" + questions.Count + "\nNaci�nij spacj�, aby przej�� do nast�pnego poziomu."; // Wy�wietlenie wyniku
        foreach (Button btn in answerButtons)
        {
            btn.gameObject.SetActive(false);
        }

        // Ustaw flag� zako�czenia quizu
        quizFinished = true;
    }

    private void LoadNextLevel()
    {
        // Pobierz indeks aktualnej sceny
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Oblicz indeks kolejnej sceny
        int nextSceneIndex = currentSceneIndex + 1;

        // Sprawd�, czy indeks kolejnej sceny istnieje w Build Settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Za�aduj kolejn� scen�
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels available. Returning to main menu.");
            SceneManager.LoadScene(1);
        }
    }

}