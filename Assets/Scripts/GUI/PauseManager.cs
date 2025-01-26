using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuCanvas;

    private bool isPaused = false; // Flaga, czy gra jest wstrzymana

    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // W³¹cz ekran pauzy
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        // Zatrzymaj czas w grze
        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        // Wy³¹cz ekran pauzy
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        // Przywróæ normalny czas w grze
        Time.timeScale = 1f;

        isPaused = false;
    }

    public void RestartLevel()
    {
        // Restartuje aktualn¹ scenê
        Time.timeScale = 1f; // Przywrócenie czasu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        // Przywróæ normalny czas i przejdŸ do menu g³ównego
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
