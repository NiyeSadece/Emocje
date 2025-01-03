using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PractiseMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadFirstQuiz()
    {
        SceneManager.LoadSceneAsync("QuizScene_1");
    }

    public void LoadSecondQuiz()
    {
        SceneManager.LoadSceneAsync("QuizScene_2");
    }

    public void LoadThirdQuiz()
    {
        SceneManager.LoadSceneAsync("QuizScene_3");
    }
}
