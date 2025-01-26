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
        // W��cz ekran pauzy
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
        // Wy��cz ekran pauzy
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        // Przywr�� normalny czas w grze
        Time.timeScale = 1f;

        isPaused = false;
    }

    public void RestartLevel()
    {
        // Restartuje aktualn� scen�
        Time.timeScale = 1f; // Przywr�cenie czasu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        // Przywr�� normalny czas i przejd� do menu g��wnego
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
