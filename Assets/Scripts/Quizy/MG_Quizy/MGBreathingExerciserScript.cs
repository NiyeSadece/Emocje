using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MGBreathingExerciserScript : MonoBehaviour
{

    private enum State { Begin, Inhale, Exhale, Complete }

    public TMP_Text messageText;   
    public TMP_Text fearLevelText;  
    private State currentState = State.Begin;
    private float timer = 0f;
    private int sequenceCount = 0;
    private const int totalSequences = 5;
    private string fearBar = "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII"; // Pocz¹tkowy pasek strachu

    void Start()
    {
        messageText.text = "Gdy dopadnie Ciê strach mo¿esz ³atwo sobie z nim poradziæ stosuj¹æ tajn¹ broñ czyli æwiczenie oddechowe. Gdy weŸmiesz kilka powolnych wdechów i wydechów, poziom strachu zacznie spadaæ. Czy jesteœ gotów by wypróbowaæ swoj¹ tajn¹ broñ? Nacisnij spacjê by rozpocz¹æ";
        fearLevelText.text = "Poziom strachu: " + fearBar; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentState == State.Begin)
        {
            StartCoroutine(StartBreathingExercise());
        }

        if (currentState == State.Inhale)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                timer += Time.deltaTime;

                // Odliczanie czasu od 5 w dó³
                float remainingTime = Mathf.Max(0f, 5f - timer);  // Pozostaj¹cy czas (nie mniej ni¿ 0)
                messageText.text = "WeŸ g³êboki wdech przez " + Mathf.CeilToInt(remainingTime).ToString() + "sek.";  // Wyœwietl odliczanie (zaokr¹glone w dó³)

                if (timer >= 5f)  // Po 5 sekundach wdechu
                {
                    messageText.text = "Wydech i puœæ spacjê";
                    currentState = State.Exhale;
                    timer = 0f;
                }
            }
        }

        if (currentState == State.Exhale)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                timer += Time.deltaTime;

                // Odliczanie czasu od 4 w dó³
                float remainingTime = Mathf.Max(0f, 4f - timer);  // Pozostaj¹cy czas (nie mniej ni¿ 0)
                messageText.text = "Wypuszczaj powietrze przez  " + Mathf.CeilToInt(remainingTime).ToString() + "sek.";  // Wyœwietl odliczanie (zaokr¹glone w dó³)

                if (timer >= 4f)  // Po 4 sekundach wydechu
                {
                    ReduceFearBar(); // Zredukuj pasek strachu

                    if (sequenceCount >= totalSequences)
                    {
                        messageText.text = "Brawo, znasz ju¿ pierwsz¹ technikê radzenia sobie ze strachem. Mo¿e siê zdarzyæ ¿e strach nie zawsze ca³kowicie zniknie lecz jak widzisz mo¿esz go skutecznie zmniejszaæ";
                        currentState = State.Complete;
                    }
                    else
                    {
                        sequenceCount++; // Zwiêksz licznik sekwencji
                        currentState = State.Inhale;
                        messageText.text = "Wdech (przytrzymaj spacjê)";
                        timer = 0f;
                    }
                }
            }
        }

        // Przejœcie do nastêpnego poziomu po zakoñczeniu æwiczenia oddechowego
        if (currentState == State.Complete && Input.GetKeyDown(KeyCode.Space))
        {
            LoadMainMenu();
        }

    }

    private void LoadMainMenu()
    {

            SceneManager.LoadScene(1);

    }

    private IEnumerator StartBreathingExercise()
    {
        messageText.text = "Wdech (przytrzymaj spacjê)";
        yield return new WaitForSeconds(1f); // chwilowa pauza
        currentState = State.Inhale;
    }

    private void ReduceFearBar()
    {
        // Losowa liczba do usuniêcia z paska strachu w przedziale od 10 do 25
        int fearReduction = Random.Range(10, 20); // Generuje liczbê od 10 do 25

        // Upewnij siê, ¿e pasek nie jest krótszy ni¿ 0 znaków
        if (fearBar.Length > fearReduction)
        {
            fearBar = fearBar.Substring(0, fearBar.Length - fearReduction);
        }
        else
        {
            fearBar = ""; // Pasek strachu jest pusty
        }

        // Zaktualizuj tekst
        fearLevelText.text = "Poziom strachu: " + fearBar;
    }
}
