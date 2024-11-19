using UnityEngine;

public class Thought : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        transform.Translate(0, -fallSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            if (gameObject.CompareTag("PositiveThought"))
            {
                // Dodaj punkty
                Debug.Log("Pozytywna my�l z�apana!");
            }
            else
            {
                // Odejmij punkty lub inna kara
                Debug.Log("Negatywna my�l z�apana!");
            }
            Destroy(gameObject);
        }
    }
}