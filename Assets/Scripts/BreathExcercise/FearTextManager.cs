using UnityEngine;
using TMPro;

public class FearTextManager : MonoBehaviour
{
    public TMP_Text fearTextUI; // UI tekstu (TextMeshPro)
    public string[] fearTexts; // Tablica tekstów
    public GameObject[] breathZones; // Tablica stref
    private bool[] hasCompletedBreathing; // Œledzenie, czy gracz zakoñczy³ oddychanie

    void Start()
    {
        // Inicjalizujemy tablicê œledz¹c¹ stan ka¿dej strefy
        hasCompletedBreathing = new bool[breathZones.Length];
        fearTextUI.gameObject.SetActive(false);
    }

    public void OnPlayerEnterZone(int zoneIndex)
    {
        if (zoneIndex >= 0 && zoneIndex < fearTexts.Length && !hasCompletedBreathing[zoneIndex])
        {
            Debug.Log($"Wyœwietlanie tekstu dla strefy {zoneIndex}");
            ShowFearText(zoneIndex);
        }
    }

    public void OnPlayerExitZone(int zoneIndex)
    {
        Debug.Log($"Gracz opuœci³ strefê {zoneIndex}, ukrywam tekst.");
        HideFearText();
    }

    private void ShowFearText(int index)
    {
        if (index >= 0 && index < fearTexts.Length)
        {
            fearTextUI.text = fearTexts[index];
            fearTextUI.gameObject.SetActive(true);
        }
    }

    private void HideFearText()
    {
        fearTextUI.gameObject.SetActive(false);
    }

    public void OnBreathLoaded(int breathZoneIndex)
    {
        if (breathZoneIndex >= 0 && breathZoneIndex < hasCompletedBreathing.Length && !hasCompletedBreathing[breathZoneIndex])
        {
            hasCompletedBreathing[breathZoneIndex] = true;
            breathZones[breathZoneIndex].SetActive(false);
            HideFearText();
        }
    }
}
