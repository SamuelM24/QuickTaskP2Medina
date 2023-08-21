using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 4.0f;
    private float gravityValue = -20.0f; // Adjusted gravity value for quicker jumps

    public void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    public void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            groundedPlayer = true;
        }

        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), 0, 0); // Invert the horizontal movement input
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue); // Adjusted gravity term for vertical jump
            groundedPlayer = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
