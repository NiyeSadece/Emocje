using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstaclePlatform : MonoBehaviour
{
    public float moveSpeed = 3f;   // Szybkoœæ ruchu przeszkody
    public float moveRange = 2f;   // Zakres ruchu (góra-dó³)
    public MessageManager messageManager;

    private Vector3 initialPosition;
    private bool movingUp = false;
    private float startY; // Pocz¹tkowa pozycja Y

    private bool isHit = false;    // Flaga, czy przeszkoda zosta³a uderzona

    void Start()
    {
        initialPosition = transform.position;
        startY = initialPosition.y;  // Przypisujemy pocz¹tkow¹ pozycjê Y
        movingUp = Random.Range(0, 2) == 1; // 50% szans, ¿e zacznie od góry, 50% od do³u
    }

    void Update()
    {
        if (!isHit) // Jeœli nie uderzyliœmy w przeszkodê
        {
            if (movingUp)
            {
                if (transform.position.y < startY + moveRange) // Dopóki nie osi¹gnie maksymalnego zasiêgu w górê
                {
                    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); // Ruch w górê
                }
                else
                {
                    movingUp = false; // Zmiana kierunku na dó³, kiedy osi¹gniemy górny limit
                }
            }
            else // Jeœli przeszkoda porusza siê w dó³
            {
                if (transform.position.y > startY - moveRange) // Dopóki nie osi¹gnie maksymalnego zasiêgu w dó³
                {
                    transform.Translate(Vector3.down * moveSpeed * Time.deltaTime); // Ruch w dó³
                }
                else
                {
                    movingUp = true; // Zmiana kierunku na górê, kiedy osi¹gniemy dolny limit
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isHit) // Sprawdzenie, czy gracz uderzy³ w przeszkodê
        {
            // Odejmowanie punktów (lub jagód)
            GameManager.instance.DeleteBerries(5); // Ustaw na 5, jeœli ma to byæ 5 punktów

            isHit = true; // Zmieniamy stan na "uderzona"
            gameObject.SetActive(false); // Ukrywamy przeszkodê po uderzeniu

            // Wyœwietlamy komunikat o stracie punktów
            messageManager.DisplayMessage("Ups! Tracisz 5 punktów!");
        }
    }
}
