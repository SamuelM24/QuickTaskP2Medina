using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line for regular UI Text

public class EndTrigger : MonoBehaviour
{
    public GameObject gameOverCanvas; // Assign the "Game Over Canvas" GameObject in the Inspector

    private bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver && other.CompareTag("Player"))
        {
            gameOverCanvas.SetActive(true); // Activate the "Game Over Canvas"
            isGameOver = true;
        }
    }
}
