using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerScene: MonoBehaviour
{
    public TextMeshProUGUI winnerScoreText; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (PersistentScore.Instance != null && winnerScoreText != null)
        {
            winnerScoreText.text = "Score: " + PersistentScore.Instance.CurrentScore.ToString();
            winnerScoreText.gameObject.SetActive(true); // Enable the score text
        }
        else
        {
            Debug.LogError("PersistentScore instance or Winner ScoreText UI element not found.");
        }
    }

    public void RestartButton()
    {
        // Reset the cursor state
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Reset the score
        if (PersistentScore.Instance != null)
        {
            PersistentScore.Instance.ResetScore();
        }
        else
        {
            Debug.LogError("PersistentScore instance not found while trying to reset the score.");
        }

        // Restart the current level
        SceneManager.LoadScene("Level 1");
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
