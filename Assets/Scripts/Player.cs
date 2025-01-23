using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;  // Pr�dko�� chodzenia
    [SerializeField] private float runSpeed = 4f;  // Pr�dko�� biegania
    [SerializeField] private float jumpForce = 5f; // Wysoko�� skoku
    private Animator animator;
    private Rigidbody rb;

    private bool isMovable = false; // Czy gracz mo�e si� porusza� (domy�lnie zablokowany)

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovable) // Je�li ruch jest zablokowany, wyjd� z metody
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f); // Zatrzymaj ruch w osi X
            animator.SetFloat("Speed", 0f); // Ustaw animacj� na brak ruchu
            return;
        }

        // Sprawdzanie, czy `Shift` jest wci�ni�ty
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Ruch w osi X
        float horizontalInput = Input.GetAxis("Horizontal"); // Warto�ci -1 dla "A", 1 dla "D"
        Vector3 velocity = new Vector3(horizontalInput * currentSpeed, rb.velocity.y, 0f); // Ruch po osi X

        // Zastosowanie pr�dko�ci do Rigidbody
        rb.velocity = velocity;

        // Aktualizowanie parametru Speed w Animatorze
        float animationSpeed = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", animationSpeed);

        // Skok
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);  // Dodajemy pr�dko�� w osi Y

        }

        // Obracanie postaci w zale�no�ci od kierunku
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f); // Obr�t w prawo
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f); // Obr�t w lewo
        }
    }

    // Ustawia mo�liwo�� poruszania si� gracza
    public void SetMovable(bool value)
    {
        isMovable = value;
    }
}
