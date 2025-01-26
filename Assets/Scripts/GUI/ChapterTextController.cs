using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapterTextController : MonoBehaviour
{
    public TextMeshProUGUI chapterText;
    public Image background;
    public float displayDuration = 3f;
    public float fadeDuration = 2f;

    public Canvas titleCanvas; // Pierwszy Canvas (Tytu� poziomu)
    public Canvas goalCanvas; // Drugi Canvas (Cel poziomu)
    public Canvas movementInstructionCanvas; // Trzeci Canvas (Instrukcja sterowania)
    public Button continueGoalButton; // Przycisk w celu poziomu
    public Button continueButton; // Przycisk w instrukcji sterowania
    public Player player;

    private void Start()
    {
        // Upewnij si�, �e pierwszy Canvas (Tytu� poziomu) jest aktywowany na pocz�tku
        if (titleCanvas != null && !titleCanvas.isActiveAndEnabled)
        {
            titleCanvas.gameObject.SetActive(true);
        }

        // Ukryj inne canvasy na pocz�tku gry
        if (goalCanvas != null)
        {
            goalCanvas.gameObject.SetActive(false);
        }

        if (movementInstructionCanvas != null)
        {
            movementInstructionCanvas.gameObject.SetActive(false);
        }

        SetAlpha(1f);

        // Zablokuj ruch gracza na czas intro
        if (player != null)
        {
            player.SetMovable(false);
        }

        // Rozpocznij korutyn� zanikania
        StartCoroutine(FadeOut());
    }

    // Ustawia przezroczysto�� (alfa) zar�wno dla tekstu, jak i t�a
    private void SetAlpha(float alpha)
    {
        Color textColor = chapterText.color;
        Color backgroundColor = background.color;

        chapterText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
        background.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
    }

    private IEnumerator FadeOut()
    {
        // Poczekaj, a� minie czas wy�wietlania tytu�u
        yield return new WaitForSeconds(displayDuration);

        float elapsedTime = 0f;

        // Zanikanie tytu�u
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(0f);
        titleCanvas.gameObject.SetActive(false); // Wy��cz tytu�

        // Rozpocznij wy�wietlanie celu poziomu
        ShowGoalCanvas();
    }

    private void ShowGoalCanvas()
    {
        if (goalCanvas != null)
        {
            goalCanvas.gameObject.SetActive(true);
        }

        // Pod��cz funkcj� do przycisku kontynuacji w celu przej�cia do nast�pnego canvasu
        if (continueGoalButton != null)
        {
            continueGoalButton.onClick.AddListener(OnContinueGoalButtonClicked);
        }
    }

    private void OnContinueGoalButtonClicked()
    {
        // Ukryj Canvas z celem
        if (goalCanvas != null)
        {
            goalCanvas.gameObject.SetActive(false);
        }


        // Odblokuj ruch gracza
        if (player != null)
        {
            player.SetMovable(true);
        }

        Debug.Log("Rozpocz�to rozgrywk�.");

        // Poka� instrukcj� sterowania
        ShowMovementInstructionCanvas();
    }

    private void ShowMovementInstructionCanvas()
    {
        // Poka� canvas z instrukcj� sterowania
        if (movementInstructionCanvas != null)
        {
            movementInstructionCanvas.gameObject.SetActive(true);
        }

        // Pod��cz funkcj� do przycisku "kontynuuj"
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinue);
        }
    }

    private void OnContinue()
    {
        // Ukryj wszystkie instrukcje
        if (movementInstructionCanvas != null)
        {
            movementInstructionCanvas.gameObject.SetActive(false);
        }

    }
}
