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
        SceneManager.LoadSceneAsync("MG_Quiz_1");
    }

    public void LoadSecondQuiz()
    {
        SceneManager.LoadSceneAsync("MG_Quiz_2");
    }

    public void LoadThirdQuiz()
    {
        SceneManager.LoadSceneAsync("MG_Quiz_3");
    }
}
