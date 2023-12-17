using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneUIManager : MonoBehaviour
{
    // You can assign this via the inspector if it's more convenient
    public GameObject scoreTextObject;
    private TextMeshProUGUI scoreTextUI;

    void Start()
    {
        // Assuming the TextMeshProUGUI component is always active on the GameObject,
        // but the GameObject itself may not be.
        scoreTextUI = scoreTextObject.GetComponent<TextMeshProUGUI>();

        // Initially set active state to false if you want it hidden by default
        scoreTextObject.SetActive(false);
    }

    // Call this method when you want to display the score
    public void ShowScore()
    {
        if (PersistentScore.Instance != null && scoreTextUI != null)
        {
            // Set the text with the current score
            scoreTextUI.text = "Score: " + PersistentScore.Instance.CurrentScore;

            // Now activate the scoreTextObject to make it visible
            scoreTextObject.SetActive(true);
        }
        else
        {
            Debug.LogError("PersistentScore instance or scoreText UI component not found.");
        }
    }

    // You could call this method when the game is over or the player reaches a checkpoint
    public void UpdateAndShowScore()
    {
        ShowScore();
        // Additional logic if needed
    }
}


