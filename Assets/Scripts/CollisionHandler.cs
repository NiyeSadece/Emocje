using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("You reached starting point");
                break;

            case "Ground":
                Debug.Log("Mmmm, nice grass under my feet");
                break;

            case "Berry":
                Debug.Log("You picked up a Berry!");
                break;

            case "Unfriendly":
                ReloadLevel();
                Debug.Log("Sorry, you died");
                break;

            case "Finish":
                LoadNextLevel();
                Debug.Log("Congrats! You reached finish point!");
                break;

            default:
                Debug.Log("Nothing happens, just go ahead");
                break;
        }
    }

    private void LoadNextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Sprawdzamy, czy nazwa aktualnej sceny to "Level 1" i przenosimy do quizu
        if (currentSceneName == "Level 1")
        {
            LoadQuizScene();
        }
        else
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // Startujemy od pocz¹tku, jeœli brak kolejnych scen
            {
                nextSceneIndex = 0; // Zak³adamy, ¿e scena startowa to pierwsza scena (indeks 0)
            }

            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    private void LoadQuizScene()
    {
        SceneManager.LoadScene("QuizScene_1"); // Upewnij siê, ¿e QuizScene_1 jest dodany w Build Settings
    }

    private void ReloadLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}