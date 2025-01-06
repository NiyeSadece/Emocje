using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Do obs�ugi tekstu UI

public class EmotionPlatform : MonoBehaviour
{
    public Canvas questionCanvas; // Canvas, na kt�rym znajduje si� pytanie i odpowiedzi
    public TextMeshProUGUI questionText; // Tekst pytania
    private bool playerIsNear = false; // Czy gracz znajduje si� w pobli�u platformy

    private void Start()
    {
        if (questionCanvas != null)
        {
            questionCanvas.gameObject.SetActive(false); // Ukryj Canvas na starcie
        }
    }

    private void Update()
    {
        // Wy�wietlanie pytania, gdy gracz jest w pobli�u
        if (playerIsNear)
        {
            ShowQuestion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            Debug.Log("Gracz w pobli�u platformy.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            HideQuestion();
            Debug.Log("Gracz oddali� si� od platformy.");
        }
    }

    public void ShowQuestion()
    {
        if (questionCanvas != null)
        {
            questionCanvas.gameObject.SetActive(true); // Pokazuje Canvas z pytaniem
            questionText.text = "Czy s�owo dotyczy strachu?"; // Ustawia tre�� pytania
        }
    }

    public void HideQuestion()
    {
        if (questionCanvas != null)
        {
            questionCanvas.gameObject.SetActive(false); // Ukrywa Canvas
        }
    }

    // Metody przypisane do przycisk�w odpowiedzi
    public void OnYesButton()
    {
        Debug.Log("Gracz odpowiedzia� TAK.");
        HideQuestion();
    }

    public void OnNoButton()
    {
        Debug.Log("Gracz odpowiedzia� NIE.");
        HideQuestion();
    }
}
