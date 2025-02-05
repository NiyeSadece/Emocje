using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstaclePlatform : MonoBehaviour
{
    public float moveSpeed = 3f;   // Szybko�� ruchu przeszkody
    public float moveRange = 2f;   // Zakres ruchu (g�ra-d�)
    public MessageManager messageManager;

    private Vector3 initialPosition;
    private bool movingUp = false;
    private float startY; // Pocz�tkowa pozycja Y

    private bool isHit = false;    // Flaga, czy przeszkoda zosta�a uderzona

    void Start()
    {
        initialPosition = transform.position;
        startY = initialPosition.y;  // Przypisujemy pocz�tkow� pozycj� Y
        movingUp = Random.Range(0, 2) == 1; // 50% szans, �e zacznie od g�ry, 50% od do�u
    }

    void Update()
    {
        if (!isHit) // Je�li nie uderzyli�my w przeszkod�
        {
            if (movingUp)
            {
                if (transform.position.y < startY + moveRange) // Dop�ki nie osi�gnie maksymalnego zasi�gu w g�r�
                {
                    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); // Ruch w g�r�
                }
                else
                {
                    movingUp = false; // Zmiana kierunku na d�, kiedy osi�gniemy g�rny limit
                }
            }
            else // Je�li przeszkoda porusza si� w d�
            {
                if (transform.position.y > startY - moveRange) // Dop�ki nie osi�gnie maksymalnego zasi�gu w d�
                {
                    transform.Translate(Vector3.down * moveSpeed * Time.deltaTime); // Ruch w d�
                }
                else
                {
                    movingUp = true; // Zmiana kierunku na g�r�, kiedy osi�gniemy dolny limit
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isHit)
        {
            // Odejmowanie punkt�w (lub jag�d)
            GameManager.instance.DeleteBerries(10);

            isHit = true; 
            gameObject.SetActive(false);

            
            messageManager.DisplayMessage("Ups! Tracisz 5 punkt�w!");
        }
    }
}
