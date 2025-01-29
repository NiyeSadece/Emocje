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
    private string fearBar = "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII"; // Pocz�tkowy pasek strachu

    void Start()
    {
        messageText.text = "Gdy dopadnie Ci� strach mo�esz �atwo sobie z nim poradzi� stosuj�� tajn� bro� czyli �wiczenie oddechowe. Gdy we�miesz kilka powolnych wdech�w i wydech�w, poziom strachu zacznie spada�. Czy jeste� got�w by wypr�bowa� swoj� tajn� bro�? Nacisnij spacj� by rozpocz��";
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

                // Odliczanie czasu od 5 w d�
                float remainingTime = Mathf.Max(0f, 5f - timer);  // Pozostaj�cy czas (nie mniej ni� 0)
                messageText.text = "We� g��boki wdech przez " + Mathf.CeilToInt(remainingTime).ToString() + "sek.";  // Wy�wietl odliczanie (zaokr�glone w d�)

                if (timer >= 5f)  // Po 5 sekundach wdechu
                {
                    messageText.text = "Wydech i pu�� spacj�";
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

                // Odliczanie czasu od 4 w d�
                float remainingTime = Mathf.Max(0f, 4f - timer);  // Pozostaj�cy czas (nie mniej ni� 0)
                messageText.text = "Wypuszczaj powietrze przez  " + Mathf.CeilToInt(remainingTime).ToString() + "sek.";  // Wy�wietl odliczanie (zaokr�glone w d�)

                if (timer >= 4f)  // Po 4 sekundach wydechu
                {
                    ReduceFearBar(); // Zredukuj pasek strachu

                    if (sequenceCount >= totalSequences)
                    {
                        messageText.text = "Brawo, znasz ju� pierwsz� technik� radzenia sobie ze strachem. Mo�e si� zdarzy� �e strach nie zawsze ca�kowicie zniknie lecz jak widzisz mo�esz go skutecznie zmniejsza�";
                        currentState = State.Complete;
                    }
                    else
                    {
                        sequenceCount++; // Zwi�ksz licznik sekwencji
                        currentState = State.Inhale;
                        messageText.text = "Wdech (przytrzymaj spacj�)";
                        timer = 0f;
                    }
                }
            }
        }

        // Przej�cie do nast�pnego poziomu po zako�czeniu �wiczenia oddechowego
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
        messageText.text = "Wdech (przytrzymaj spacj�)";
        yield return new WaitForSeconds(1f); // chwilowa pauza
        currentState = State.Inhale;
    }

    private void ReduceFearBar()
    {
        // Losowa liczba do usuni�cia z paska strachu w przedziale od 10 do 25
        int fearReduction = Random.Range(10, 20); // Generuje liczb� od 10 do 25

        // Upewnij si�, �e pasek nie jest kr�tszy ni� 0 znak�w
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
