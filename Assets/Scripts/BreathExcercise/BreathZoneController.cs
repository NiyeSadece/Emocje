using UnityEngine;

public class BreathZoneController : MonoBehaviour
{
    public int zoneIndex; // Indeks strefy
    public FearTextManager fearTextManager; // Odwo�anie do managera tekstu

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player wszed� do strefy: {zoneIndex}");
            fearTextManager.OnPlayerEnterZone(zoneIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player opu�ci� stref�: {zoneIndex}");
            fearTextManager.OnPlayerExitZone(zoneIndex);
        }
    }
}
