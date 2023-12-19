using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Reference to the 'Game Over' text
    public TextMeshProUGUI scoreText; // Reference to the score text

    // Call this Setup method from wherever you handle the game over logic.
    public void Setup()
    {
        gameObject.SetActive(true); // Activating the game over screen

        // Unlock the cursor for the game over menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Make sure the Game Over text is active
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        // Update and show the score from the PersistentScore instance
        if (scoreText != null && PersistentScore.Instance != null)
        {
            scoreText.gameObject.SetActive(true); // Make sure the Score text is active
            scoreText.text = "Score: " + PersistentScore.Instance.CurrentScore; // Set the score text
        }
        else
        {
            Debug.LogError("ScoreText or PersistentScore instance not found.");
        }
    }

    // Restart the current level and reset the score
    public void RestartButton()
    {
        // Restart the current level
        SceneManager.LoadScene("Level 1");

        // Reset the score
        if (PersistentScore.Instance != null)
        {
            PersistentScore.Instance.ResetScore();
        }
        else
        {
            Debug.LogError("PersistentScore instance not found while trying to reset the score.");
        }     
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");

        // Reset the score
        if (PersistentScore.Instance != null)
        {
            PersistentScore.Instance.ResetScore();
        }
        else
        {
            Debug.LogError("PersistentScore instance not found while trying to reset the score.");
        }
    }
}

