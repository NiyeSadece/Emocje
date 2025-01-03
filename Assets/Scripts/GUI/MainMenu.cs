using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadSceneAsync(nextSceneIndex);
    }

    public void LoadPractiseMenu()
    {
        SceneManager.LoadSceneAsync("PractiseMenu");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadSceneAsync("OptionsMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
