using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Potrzebne do Image dla t³a
using TMPro; // Potrzebne do TextMeshPro

public class ChapterTextController : MonoBehaviour
{
    public TextMeshProUGUI chapterText; // Odniesienie do tekstu TMP
    public Image background; // Odniesienie do t³a (Image)
    public float displayDuration = 3f; // Czas wyœwietlania tekstu
    public float fadeDuration = 2f; // Czas zanikania

    public Canvas canvas; // Odniesienie do Canvasu (który zawiera t³o i tekst)

    private void Start()
    {
        // Pobierz Canvas z obiektu, do którego przypisany jest skrypt
        canvas = GetComponent<Canvas>();

        // Upewnij siê, ¿e Canvas jest aktywowany, jeœli nie jest widoczny
        if (canvas != null && !canvas.isActiveAndEnabled)
        {
            canvas.gameObject.SetActive(true); // Aktywujemy Canvas, jeœli nie jest aktywny
        }

        // Ustaw pe³n¹ widocznoœæ tekstu i t³a na starcie
        SetAlpha(1f);

        // Rozpocznij korutynê zanikania
        StartCoroutine(FadeOut());
    }

    // Ustawia przezroczystoœæ (alfa) zarówno dla tekstu, jak i t³a
    private void SetAlpha(float alpha)
    {
        Color textColor = chapterText.color;
        Color backgroundColor = background.color;

        // Ustawiamy alfa dla tekstu
        chapterText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);

        // Ustawiamy alfa dla t³a
        background.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
    }

    private IEnumerator FadeOut()
    {
        // Poczekaj, a¿ minie czas wyœwietlania
        yield return new WaitForSeconds(displayDuration);

        float elapsedTime = 0f;

        // Zanikanie tekstu i t³a
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Obliczamy now¹ wartoœæ alfa w oparciu o czas, aby oba elementy zanika³y w tym samym tempie
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Ustawiamy tê sam¹ wartoœæ alfa dla tekstu i t³a
            SetAlpha(alpha);

            yield return null; // Czekaj do nastêpnej klatki
        }

        // Upewniamy siê, ¿e na koñcu alfa jest równe 0
        SetAlpha(0f);

        // Wy³¹czamy elementy po zanikniêciu
        chapterText.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

        // Rozpocznij rozgrywkê po zaniku
        StartGameplay();
    }

    private void StartGameplay()
    {
        // Logika rozpoczêcia gry, np. odblokowanie ruchu gracza, rozpoczêcie czasu itp.
        Debug.Log("Rozpoczynamy grê!");
    }
}
