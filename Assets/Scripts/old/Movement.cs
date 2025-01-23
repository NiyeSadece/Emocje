using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float walkSpeed = 5.0f;  // Prêdkoœæ chodzenia
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessJump();
        ProcessWalk();
    }

    private void ProcessJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // U¿ycie GetKeyDown, aby skok by³ jednokrotny
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void ProcessWalk()
    {
        Vector3 moveDirection = Vector3.zero;

        // Ruch w lewo
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDirection = Vector3.left;
        }
        // Ruch w prawo
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDirection = Vector3.right;
        }

        // Zastosowanie prêdkoœci chodzenia
        rb.velocity = new Vector3(moveDirection.x * walkSpeed, rb.velocity.y, rb.velocity.z);
    }
}
