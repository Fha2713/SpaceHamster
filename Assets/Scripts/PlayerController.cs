using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private bool canJump = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    void OnJump(InputValue jumpValue)
    {
        if (jumpValue.isPressed && canJump)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            canJump = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            transform.position = new Vector3(0, 1, 0);
            rb.linearVelocity = Vector3.zero;
        }
    }
}
