using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Potrzebne do Image dla t�a
using TMPro; // Potrzebne do TextMeshPro

public class ChapterTextController : MonoBehaviour
{
    public TextMeshProUGUI chapterText; // Odniesienie do tekstu TMP
    public Image background; // Odniesienie do t�a (Image)
    public float displayDuration = 3f; // Czas wy�wietlania tekstu
    public float fadeDuration = 2f; // Czas zanikania

    public Canvas canvas; // Odniesienie do Canvasu (kt�ry zawiera t�o i tekst)
    public Canvas instructionCanvas; // Odniesienie do Canvasu z instrukcj�
    public Button continueButton; // Przycisk "Dalej"
    public Player player; // Odniesienie do obiektu gracza

    private void Start()
    {
        // Pobierz Canvas z obiektu, do kt�rego przypisany jest skrypt
        canvas = GetComponent<Canvas>();

        // Upewnij si�, �e Canvas jest aktywowany, je�li nie jest widoczny
        if (canvas != null && !canvas.isActiveAndEnabled)
        {
            canvas.gameObject.SetActive(true); // Aktywujemy Canvas, je�li nie jest aktywny
        }

        // Ustaw pe�n� widoczno�� tekstu i t�a na starcie
        SetAlpha(1f);

        // Zablokuj ruch gracza
        if (player != null)
        {
            player.SetMovable(false);
        }

        // Upewnij si�, �e drugi Canvas jest wy��czony na starcie
        if (instructionCanvas != null)
        {
            instructionCanvas.gameObject.SetActive(false);
        }
        // Rozpocznij korutyn� zanikania
        StartCoroutine(FadeOut());
    }

    // Ustawia przezroczysto�� (alfa) zar�wno dla tekstu, jak i t�a
    private void SetAlpha(float alpha)
    {
        Color textColor = chapterText.color;
        Color backgroundColor = background.color;

        // Ustawiamy alfa dla tekstu
        chapterText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);

        // Ustawiamy alfa dla t�a
        background.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
    }

    private IEnumerator FadeOut()
    {
        // Poczekaj, a� minie czas wy�wietlania
        yield return new WaitForSeconds(displayDuration);

        float elapsedTime = 0f;

        // Zanikanie tekstu i t�a
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Obliczamy now� warto�� alfa w oparciu o czas, aby oba elementy zanika�y w tym samym tempie
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Ustawiamy t� sam� warto�� alfa dla tekstu i t�a
            SetAlpha(alpha);

            yield return null; // Czekaj do nast�pnej klatki
        }

        // Upewniamy si�, �e na ko�cu alfa jest r�wne 0
        SetAlpha(0f);

        // Wy��czamy pierwszy Canvas
        canvas.gameObject.SetActive(false);

        // Rozpocznij rozgrywk� po zaniku
        StartGameplay();

        // Aktywuj drugi Canvas
        ShowInstructionCanvas();

    }

    private void StartGameplay()
    {
        // Logika rozpocz�cia gry, np. odblokowanie ruchu gracza, rozpocz�cie czasu itp.
        Debug.Log("Rozpoczynamy gr�!");
    }

    private void ShowInstructionCanvas()
    {
        if (instructionCanvas != null)
        {
            instructionCanvas.gameObject.SetActive(true);
            Debug.Log("Pokazano instrukcj�.");
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinue);
        }
    }

    private void OnContinue()
    {
        // Ukryj Canvas z instrukcj�
        if (instructionCanvas != null)
        {
            instructionCanvas.gameObject.SetActive(false);
        }

        // Odblokuj ruch gracza
        if (player != null)
        {
            player.SetMovable(true);
        }

        Debug.Log("Rozpocz�to rozgrywk�.");
    }
}
