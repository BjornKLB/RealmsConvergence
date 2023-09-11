using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    public float lookSpeed = 2f;
    public float lookXLimit = 60f;

    private Rigidbody rb;
    private Transform playerCameraTransform;
    private float rotationX = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * horizontal + transform.forward * vertical).normalized;
        Vector3 velocity = movement * moveSpeed;

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 1.1f; // Adjust this based on your player's collider size
        Vector3 raycastOrigin = transform.position + Vector3.up * 0.1f; // Adjust this based on your player's collider size and position

        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, raycastDistance))
        {
            return true;
        }

        return false;
    }
}