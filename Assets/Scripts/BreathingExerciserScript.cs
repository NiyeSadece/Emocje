using System.Collections;
using System.Collections.Generic;
using TMPro;  // Dodaj ten namespace
using UnityEngine;
using UnityEngine.UI;

public class BreathingExercise : MonoBehaviour
{
    private enum State { Begin, Inhale, Exhale, Complete }

    public TMP_Text messageText;  // Zmieniamy typ na TMP_Text
    private State currentState = State.Begin;
    private float timer = 0f;
    private int sequenceCount = 0;
    private const int totalSequences = 10;

    void Start()
    {
        messageText.text = "Æwiczenie oddechowe\nNaciœnij spacjê, aby rozpocz¹æ";
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
                if (timer >= 5f)
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
                if (timer >= 7f)
                {
                    sequenceCount++;
                    if (sequenceCount >= totalSequences)
                    {
                        messageText.text = "Brawo, znasz ju¿ pierwsz¹ technikê radzenia sobie ze strachem";
                        currentState = State.Complete;
                    }
                    else
                    {
                        currentState = State.Inhale;
                        messageText.text = "Wdech (przytrzymaj spacjê)";
                        timer = 0f;
                    }
                }
            }
        }
    }

    private IEnumerator StartBreathingExercise()
    {
        messageText.text = "Wdech (przytrzymaj spacjê)";
        yield return new WaitForSeconds(1f); // chwilowa pauza
        currentState = State.Inhale;
    }
}