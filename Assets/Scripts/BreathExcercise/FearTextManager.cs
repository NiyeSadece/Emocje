using UnityEngine;
using TMPro;

public class FearTextManager : MonoBehaviour
{
    public TMP_Text fearTextUI; // UI tekstu (TextMeshPro)
    public string[] fearTexts; // Tablica tekst�w
    public GameObject[] breathZones; // Tablica stref
    private bool[] hasCompletedBreathing; // �ledzenie, czy gracz zako�czy� oddychanie

    void Start()
    {
        // Inicjalizujemy tablic� �ledz�c� stan ka�dej strefy
        hasCompletedBreathing = new bool[breathZones.Length];
        fearTextUI.gameObject.SetActive(false);
    }

    public void OnPlayerEnterZone(int zoneIndex)
    {
        if (zoneIndex >= 0 && zoneIndex < fearTexts.Length && !hasCompletedBreathing[zoneIndex])
        {
            Debug.Log($"Wy�wietlanie tekstu dla strefy {zoneIndex}");
            ShowFearText(zoneIndex);
        }
    }

    public void OnPlayerExitZone(int zoneIndex)
    {
        Debug.Log($"Gracz opu�ci� stref� {zoneIndex}, ukrywam tekst.");
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
