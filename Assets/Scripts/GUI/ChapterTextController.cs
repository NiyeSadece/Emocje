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

    public Canvas titleCanvas; // Pierwszy Canvas (Tytu³ poziomu)
    public Canvas goalCanvas; // Drugi Canvas (Cel poziomu)
    public Canvas movementInstructionCanvas; // Trzeci Canvas (Instrukcja sterowania)
    public Button continueGoalButton; // Przycisk w celu poziomu
    public Button continueButton; // Przycisk w instrukcji sterowania
    public Player player;

    private void Start()
    {
        // Upewnij siê, ¿e pierwszy Canvas (Tytu³ poziomu) jest aktywowany na pocz¹tku
        if (titleCanvas != null && !titleCanvas.isActiveAndEnabled)
        {
            titleCanvas.gameObject.SetActive(true);
        }

        // Ukryj inne canvasy na pocz¹tku gry
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

        // Rozpocznij korutynê zanikania
        StartCoroutine(FadeOut());
    }

    // Ustawia przezroczystoœæ (alfa) zarówno dla tekstu, jak i t³a
    private void SetAlpha(float alpha)
    {
        Color textColor = chapterText.color;
        Color backgroundColor = background.color;

        chapterText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
        background.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
    }

    private IEnumerator FadeOut()
    {
        // Poczekaj, a¿ minie czas wyœwietlania tytu³u
        yield return new WaitForSeconds(displayDuration);

        float elapsedTime = 0f;

        // Zanikanie tytu³u
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(0f);
        titleCanvas.gameObject.SetActive(false); // Wy³¹cz tytu³

        // Rozpocznij wyœwietlanie celu poziomu
        ShowGoalCanvas();
    }

    private void ShowGoalCanvas()
    {
        if (goalCanvas != null)
        {
            goalCanvas.gameObject.SetActive(true);
        }

        // Pod³¹cz funkcjê do przycisku kontynuacji w celu przejœcia do nastêpnego canvasu
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

        Debug.Log("Rozpoczêto rozgrywkê.");

        // Poka¿ instrukcjê sterowania
        ShowMovementInstructionCanvas();
    }

    private void ShowMovementInstructionCanvas()
    {
        // Poka¿ canvas z instrukcj¹ sterowania
        if (movementInstructionCanvas != null)
        {
            movementInstructionCanvas.gameObject.SetActive(true);
        }

        // Pod³¹cz funkcjê do przycisku "kontynuuj"
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
