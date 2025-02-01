using UnityEngine;

public class BreathZoneTrigger : MonoBehaviour
{
    public GameObject breathBarUI;
    public BreathController breathController; // Referencja do BreathController
    public int breathZoneIndex; // Indeks BreathZone
    public FearTextManager fearTextManager; // Odwo�anie do managera tekstu

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // W��cz pasek oddechu i aktywuj BreathZone
            if (breathBarUI != null)
            {
                breathBarUI.SetActive(true); // W��cz pasek
            }

            if (breathController != null)
            {
                breathController.breathZoneIndex = breathZoneIndex; // Ustaw indeks strefy oddechu
                breathController.ActivateBreathZone(); // Aktywuj BreathZone w BreathController
                fearTextManager.OnPlayerEnterZone(breathZoneIndex);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Wy��cz pasek oddechu
            if (breathBarUI != null)
            {
                breathBarUI.SetActive(false); // Wy��cz pasek
            }

            // Zresetuj BreathZone w BreathController, je�li nie chcesz, aby gracz m�g� wr�ci� do tej strefy
            if (breathController != null)
            {
                breathController.breathZoneIndex = -1; // Resetuj indeks, je�li chcesz, by BreathZone by�a nieaktywna
                breathController.ResetBreathBar(); // Resetuj pasek, aby gracz nie mia� mo�liwo�ci kontynuowania oddechu
                fearTextManager.OnPlayerExitZone(breathZoneIndex);
            }
        }
    }
}
