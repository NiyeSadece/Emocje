using UnityEngine;

public class BreathZoneController : MonoBehaviour
{
    public int zoneIndex; // Indeks strefy
    public FearTextManager fearTextManager; // Odwo³anie do managera tekstu

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player wszed³ do strefy: {zoneIndex}");
            fearTextManager.OnPlayerEnterZone(zoneIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player opuœci³ strefê: {zoneIndex}");
            fearTextManager.OnPlayerExitZone(zoneIndex);
        }
    }
}
