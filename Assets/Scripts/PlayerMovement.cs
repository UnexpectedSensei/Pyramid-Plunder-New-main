using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 35.0f; // Adjust this value to control movement speed.
    private CharacterController characterController;

    public Transform cameraTransform; // Reference to the camera's transform
    public float lookSpeed = 2.0f; // Adjust this value to control camera sensitivity

    private float rotationX = 0.0f; // Current camera rotation on the X-axis

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input for player movement.
        float horizontalInput = Input.GetAxis("Horizontal"); // Left/Right arrow keys
        float verticalInput = Input.GetAxis("Vertical"); // Up/Down arrow keys

        // Calculate the movement vector.
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement = transform.TransformDirection(movement) * moveSpeed;

        // Apply the movement to the CharacterController.
        characterController.Move(movement * Time.deltaTime);

        // Camera Look Input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player's transform based on mouse input for camera control
        transform.Rotate(Vector3.up * mouseX * lookSpeed);

        // Calculate the camera's rotation on the X-axis
        rotationX -= mouseY * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -45.0f, 45.0f);

        // Apply the camera rotation
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}

