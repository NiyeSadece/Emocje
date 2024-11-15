using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmotionQuizManager : MonoBehaviour
{
    public TextMeshProUGUI situationText;
    public GameObject dropZone;
    public List<GameObject> draggableTexts;
    public TextMeshProUGUI feedbackText;

    void Start()
    {
        UpdateTask();
    }

    public void UpdateTask()
    {
        // Tylko przyk³ad: Uzupe³nij w zale¿noœci od specyfiki Twojego projektu.
        if (situationText != null)
        {
            situationText.text = "Kasia siê boi."; // Ustawienie przyk³adowego tekstu
        }

        if (feedbackText != null)
        {
            feedbackText.text = ""; // Czyszczenie feedbacku
        }
    }

    public void ProvideFeedback(string feedback)
    {
        if (feedbackText != null)
        {
            feedbackText.text = feedback;
        }
    }
}