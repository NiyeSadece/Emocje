using UnityEngine;
using UnityEngine.UI;

public class BreathController : MonoBehaviour
{
    public Slider breathBar; // Pasek oddechu
    public float fillSpeed = 0.5f; // Jak szybko pasek si� nape�nia
    private bool isFilling = false; // Czy pasek jest wype�niany?
    private bool breathCompleted = false; // Czy oddech zosta� zako�czony w tej strefie?
    public int breathZoneIndex; // Indeks BreathZone
    public FearTextManager fearTextManager; // Przypisany skrypt FearTextManager

    void Start()
    {
        ResetState(); // Inicjalizacja stanu na pocz�tku
    }

    void Update()
    {
        if (breathBar.gameObject.activeSelf) // Sprawdzamy, czy pasek jest aktywny
        {
            if (!breathBar.gameObject.activeSelf)
            {
                Debug.Log("BreathBar is not active in Update.");
                return;
            }


            Debug.Log("Update dzia�a w BreathController"); // TES
            // Wci�ni�cie klawisza "W" zaczyna wdech
            if (Input.GetKey(KeyCode.W) && !breathCompleted)
            {
                isFilling = true;
                FillBreathBar();
            }
            else
            {
                isFilling = false;
                ResetBreathBar();
            }

            // Sprawdzenie, czy pasek jest pe�ny, i wywo�anie metody po zako�czeniu oddechu
            if (breathBar.value >= breathBar.maxValue && !breathCompleted)
            {
                breathCompleted = true;
                OnBreathLoaded();
            }
        }
    }

    void FillBreathBar()
    {
        if (isFilling && breathBar.value < breathBar.maxValue)
        {
            breathBar.value += fillSpeed * Time.deltaTime;
        }
    }

    public void ResetBreathBar()
    {
        if (!isFilling && breathBar.value > 0)
        {
            breathBar.value -= fillSpeed * Time.deltaTime;
        }
    }

    void OnBreathLoaded()
    {
        // Po zako�czeniu �adowania paska oddechowego wywo�aj metod� w FearTextManager
        if (fearTextManager != null)
        {
            fearTextManager.OnBreathLoaded(breathZoneIndex);
        }

        // Ukryj pasek po zako�czeniu �adowania
        breathBar.gameObject.SetActive(false);
    }

    // Funkcja uruchamiaj�ca BreathZone
    public void ActivateBreathZone()
    {
        Debug.Log("ActivateBreathZone called. Resetting state.");
        if (breathBar != null)
        {
            breathBar.gameObject.SetActive(true); // Poka� pasek, gdy BreathZone jest aktywna
            breathCompleted = false; // Resetujemy stan na "nieuko�czony"
            breathBar.value = 0; // Resetujemy warto�� paska
            isFilling = false; // Pasek nie jest wype�niany
        }
    }

    // Funkcja resetuj�ca stan, przydatna przy przej�ciu mi�dzy scenami
    public void ResetState()
    {
        isFilling = false;
        breathCompleted = false;
        if (breathBar != null)
        {
            breathBar.value = 0; // Resetuj warto�� paska
            breathBar.gameObject.SetActive(false); // Ukryj pasek na starcie
        }
    }
}
