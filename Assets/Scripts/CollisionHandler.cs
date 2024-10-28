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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Sprawdzamy, czy jesteœmy na poziomie 1 i przenosimy do quizu
        if (currentSceneIndex == 1)
        {
            LoadQuizScene();
        }
        else
        {
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // Startujemy od pocz¹tku, jeœli brak kolejnych scen
            {
                nextSceneIndex = 1;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    private void LoadQuizScene()
    {
        SceneManager.LoadScene("QuizScene"); // Upewnij siê, ¿e QuizScene jest dodany w Build Settings
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}