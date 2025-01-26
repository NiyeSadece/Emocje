using UnityEngine;
using UnityEngine.UI;

public class BreathController : MonoBehaviour
{
    public Slider breathBar; // Pasek oddechu
    public float fillSpeed = 0.5f; // Jak szybko pasek siê nape³nia
    private bool isFilling = false; // Czy pasek jest wype³niany?
    private bool breathCompleted = false; // Czy oddech zosta³ zakoñczony w tej strefie?
    public int breathZoneIndex; // Indeks BreathZone
    public FearTextManager fearTextManager; // Przypisany skrypt FearTextManager

    void Start()
    {
        ResetState(); // Inicjalizacja stanu na pocz¹tku
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


            Debug.Log("Update dzia³a w BreathController"); // TES
            // Wciœniêcie klawisza "W" zaczyna wdech
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

            // Sprawdzenie, czy pasek jest pe³ny, i wywo³anie metody po zakoñczeniu oddechu
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
        // Po zakoñczeniu ³adowania paska oddechowego wywo³aj metodê w FearTextManager
        if (fearTextManager != null)
        {
            fearTextManager.OnBreathLoaded(breathZoneIndex);
        }

        // Ukryj pasek po zakoñczeniu ³adowania
        breathBar.gameObject.SetActive(false);
    }

    // Funkcja uruchamiaj¹ca BreathZone
    public void ActivateBreathZone()
    {
        Debug.Log("ActivateBreathZone called. Resetting state.");
        if (breathBar != null)
        {
            breathBar.gameObject.SetActive(true); // Poka¿ pasek, gdy BreathZone jest aktywna
            breathCompleted = false; // Resetujemy stan na "nieukoñczony"
            breathBar.value = 0; // Resetujemy wartoœæ paska
            isFilling = false; // Pasek nie jest wype³niany
        }
    }

    // Funkcja resetuj¹ca stan, przydatna przy przejœciu miêdzy scenami
    public void ResetState()
    {
        isFilling = false;
        breathCompleted = false;
        if (breathBar != null)
        {
            breathBar.value = 0; // Resetuj wartoœæ paska
            breathBar.gameObject.SetActive(false); // Ukryj pasek na starcie
        }
    }
}
