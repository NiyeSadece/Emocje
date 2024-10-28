using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons;

    public List<Question> questions;
    private int currentQuestionIndex;

    void Start()
    {
        currentQuestionIndex = 0;
        DisplayQuestion();
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
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void WrongAnswer()
    {
        // Tutaj mo¿na dodaæ logikê na wypadek b³êdnej odpowiedzi
    }

    void FinishQuiz()
    {
        questionText.text = "Quiz Finished!";
        foreach (Button btn in answerButtons)
        {
            btn.gameObject.SetActive(false);
        }

        // Przejœcie do poziomu 2
        SceneManager.LoadScene(3); // Za³aduj poziom 2, zak³adaj¹c, ¿e ma indeks 3
    }
}
