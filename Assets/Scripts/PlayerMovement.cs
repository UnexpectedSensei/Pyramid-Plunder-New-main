using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this value to control movement speed.
    private Rigidbody rb;

    public Transform cameraTransform; // Reference to the camera's transform
    public float lookSpeed = 2.0f; // Adjust this value to control camera sensitivity

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Input for player movement.
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float verticalInput = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Calculate the movement vector.
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Normalize the vector to prevent faster diagonal movement.
        movement.Normalize();

        // Apply the movement to the Rigidbody.
        rb.velocity = transform.TransformDirection(movement) * moveSpeed;

        // Camera Look Input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player's transform based on mouse input for camera control
        transform.Rotate(Vector3.up * mouseX * lookSpeed);

        // Rotate the camera's transform based on mouse input for looking up and down
        cameraTransform.Rotate(Vector3.left * mouseY * lookSpeed);

        // Clamp the camera rotation to prevent over-rotation
        Vector3 currentRotation = cameraTransform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);
        cameraTransform.localEulerAngles = currentRotation;
    }
}
