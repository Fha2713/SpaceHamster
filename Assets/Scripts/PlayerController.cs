using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float FlySpeed = 10f;
    [SerializeField] float MouseSensitivity = 2f;

    private Rigidbody rb;
    private Camera cam;
    private Vector3 moveInput;
    private float yaw;
    private float pitch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = 0f;
        cam = Camera.main;
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handle look
        transform.rotation = Quaternion.Euler(0, yaw, 0);
        cam.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    void FixedUpdate()
    {
        // Move in the look direction (camera's forward/right/up)
        Vector3 direction = (transform.right * moveInput.x) + (cam.transform.forward * moveInput.y);
        rb.linearVelocity = direction.normalized * FlySpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>() * MouseSensitivity;
        yaw += look.x;
        pitch -= look.y;
        pitch = Mathf.Clamp(pitch, -89f, 89f);
    }
}
