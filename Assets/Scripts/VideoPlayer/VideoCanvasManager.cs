using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoCanvasManager : MonoBehaviour
{
    [Header("Video Player Settings")]
    public VideoPlayer videoPlayer; // Obiekt Video Player

    [Header("Canvas Settings")]
    public GameObject buttonsCanvas; // Canvas z przyciskami
    public double buttonShowTime = 2.0; // Czas w sekundach, kiedy przyciski maj� si� pojawi�

    [Header("Second Canvas Settings")]
    public GameObject secondCanvas; // Canvas z now� histori�
    public float secondCanvasDelay = 0.5f; // Op�nienie w sekundach dla drugiego Canvasu

    private bool buttonsShown = false; // Flaga, aby przyciski pokaza�y si� tylko raz
    private bool secondCanvasShown = false; // Flaga, aby drugi Canvas pokaza� si� tylko raz

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
            if (videoPlayer == null)
            {
                Debug.LogError("Brak przypisanego VideoPlayera i nie znaleziono go w obiekcie!");
                return;
            }
        }

        if (buttonsCanvas != null)
        {
            buttonsCanvas.SetActive(false); // Ukrycie Canvasu na starcie
        }

        if (secondCanvas != null)
        {
            secondCanvas.SetActive(false); // Ukrycie drugiego Canvasu na starcie
        }
    }

    void Update()
    {
        if (videoPlayer != null && videoPlayer.time >= buttonShowTime && !buttonsShown)
        {
            ShowButtons();
        }
    }

    private void ShowButtons()
    {
        if (buttonsCanvas != null)
        {
            buttonsCanvas.SetActive(true); // Pokazanie Canvasu
        }

        if (videoPlayer != null)
        {
            videoPlayer.Pause(); // Zatrzymanie wideo
        }

        buttonsShown = true;
    }

    public void ResumeVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play(); // Wznawia odtwarzanie wideo
        }

        if (buttonsCanvas != null)
        {
            buttonsCanvas.SetActive(false); // Ukrycie Canvasu z UI
        }

        // Uruchomienie timera do pokazania drugiego Canvasu
        if (!secondCanvasShown)
        {
            Invoke("ShowSecondCanvas", secondCanvasDelay); // Op�nione wywo�anie
        }
    }

    private void ShowSecondCanvas()
    {
        if (secondCanvas != null)
        {
            secondCanvas.SetActive(true); // Pokazanie drugiego Canvasu
        }

        secondCanvasShown = true; // Zapobiega wielokrotnemu wywo�aniu
    }

    // Funkcja przypisana do pierwszego przycisku (przej�cie do poziomu 1)
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // �adowanie nast�pnej sceny
    }

    // Funkcja przypisana do drugiego przycisku (powr�t do menu g��wnego)
    public void ReturnToPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1); // �adowanie poprzedniej sceny
    }
}
