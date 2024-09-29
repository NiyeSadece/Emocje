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
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) //Starting from the begging if there is no more scenes added in build settings
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
