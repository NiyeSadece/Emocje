using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    public string quizSceneName; 



    private void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;

        Debug.Log($"Collision detected with tag: {tag}");

        switch (tag)
        {
            case "Start":
                HandleStartPoint();
                break;

            case "Ground":
                HandleGroundCollision();
                break;

            case "Berry":
                HandleBerryPickup();
                break;

            case "Unfriendly":
                HandleUnfriendlyCollision();
                break;

            case "Finish":
                HandleFinishPoint();
                break;

            default:
                HandleDefaultCollision();
                break;
        }
    }

    private void HandleStartPoint()
    {
        Debug.Log("You reached the starting point.");
    }

    private void HandleGroundCollision()
    {
        Debug.Log("Mmmm, nice grass under my feet.");
    }

    private void HandleBerryPickup()
    {
        Debug.Log("You picked up a Berry!");
    }

    private void HandleUnfriendlyCollision()
    {
        Debug.Log("Sorry, you died.");
        ReloadLevel();
    }

    private void HandleFinishPoint()
    {
        Debug.Log("Congrats! You reached the finish point!");
        LoadQuizScene();
    }

    private void HandleDefaultCollision()
    {
        Debug.Log("Nothing happens, just go ahead.");
    }

    private void LoadQuizScene()
    {
        // Indeks aktualnej sceny
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int quizIndex = currentSceneIndex +1;

        if (quizIndex >= 0 && quizIndex <= 7)
        {
         
            Debug.Log($"Loading quiz scene: {quizSceneName}");
            SceneManager.LoadScene(quizSceneName);
        }
        else
        {
            Debug.LogError(quizIndex);
            Debug.LogError("Quiz scene not found or not configured properly!");
        }
    }

    private void ReloadLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
