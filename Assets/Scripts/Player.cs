using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 5f;  // Wysoko�� skoku
    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        // Upewnij si�, �e Rigidbody nie jest kinetyczne
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Ruch w osi X
        float horizontalInput = Input.GetAxis("Horizontal");  // Warto�ci -1 dla "A", 1 dla "D"
        Vector3 velocity = new Vector3(horizontalInput * speed, rb.velocity.y, 0f);  // Ruch po osi X

        // Zastosowanie pr�dko�ci do Rigidbody
        rb.velocity = velocity;

        // Aktualizowanie animacji na podstawie pr�dko�ci
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Sprawdzanie, czy gracz dotyka ziemi, aby skaka�
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);  // Sprawdzamy, czy na ziemi

        if (isGrounded && Input.GetKeyDown(KeyCode.W))  // Skok
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);  // Dodajemy pr�dko�� w osi Y
            animator.SetTrigger("Jump");  // Wywo�anie animacji skoku (je�li jest ustawiona)
            Debug.Log("Skok");
        }

        // Obracanie postaci w zale�no�ci od kierunku
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);  // Obr�t w prawo
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);  // Obr�t w lewo
        }
    }
}

//{
//    [SerializeField] private float speed = 2f;

//    private Animator animator;

//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Ruch w osi X
//        float horizontalInput = Input.GetAxis("Horizontal");  // Warto�ci -1 dla "A", 1 dla "D"
//        var velocity = Vector3.right * horizontalInput * speed;  // Ruch po osi X (lewo/prawo)

//        // Aktualizowanie animacji na podstawie pr�dko�ci
//        animator.SetFloat("Speed", Mathf.Abs(velocity.x));

//        // Translacja postaci
//        transform.Translate(velocity * Time.deltaTime, Space.World);

//        // Obr�t postaci
//        if (horizontalInput > 0)
//        {
//            // Obr�t w prawo
//            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
//        }
//        else if (horizontalInput < 0)
//        {
//            // Obr�t w lewo
//            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
//        }
//    }
//}


//{
//    [SerializeField] private float speed = 2f;

//    private Animator animator;

//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        var velocity = Vector3.forward * Input.GetAxis("Horizontal") * speed;

//        transform.Translate(velocity * Time.deltaTime);
//        animator.SetFloat("Speed", velocity.z);
//    }
//}
