using UnityEngine;

public class BreathZoneTrigger : MonoBehaviour
{
    public GameObject breathBarUI; // Pasek oddechu
    public BreathController breathController; // Referencja do BreathController
    public int breathZoneIndex; // Indeks BreathZone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // W³¹cz pasek oddechu i aktywuj BreathZone
            if (breathBarUI != null)
            {
                breathBarUI.SetActive(true); // W³¹cz pasek
            }

            if (breathController != null)
            {
                breathController.breathZoneIndex = breathZoneIndex; // Ustaw indeks strefy oddechu
                breathController.ActivateBreathZone(); // Aktywuj BreathZone w BreathController
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Wy³¹cz pasek oddechu
            if (breathBarUI != null)
            {
                breathBarUI.SetActive(false); // Wy³¹cz pasek
            }

            // Zresetuj BreathZone w BreathController, jeœli nie chcesz, aby gracz móg³ wróciæ do tej strefy
            if (breathController != null)
            {
                breathController.breathZoneIndex = -1; // Resetuj indeks, jeœli chcesz, by BreathZone by³a nieaktywna
                breathController.ResetBreathBar(); // Resetuj pasek, aby gracz nie mia³ mo¿liwoœci kontynuowania oddechu
            }
        }
    }
}
