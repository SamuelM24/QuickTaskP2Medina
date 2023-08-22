using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpVelocity = 12.0f; // Instant jump velocity
    private float gravityValue = -20.0f; // Adjusted gravity value for quicker jumps

    private Vector3 playerVelocity; // Add this line

    public void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    public void Update()
    {
        groundedPlayer = controller.isGrounded;
        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), 0, 0); // Invert the horizontal movement input

        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // Apply instant jump velocity
                playerVelocity.y = jumpVelocity;
                groundedPlayer = false;
            }
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Apply movement
        controller.Move((move * playerSpeed + playerVelocity) * Time.deltaTime);

        // Set groundedPlayer based on controller.isGrounded after movement
        groundedPlayer = controller.isGrounded;
    }
}
