using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    public string playerTag = "Player";

    public TextMeshProUGUI scoreText; // Reference to the ScoreText component

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null && playerInventory.HasKey)
            {
                // Enable the score text and update its content
                if (scoreText != null)
                {
                    scoreText.gameObject.SetActive(true);
                    scoreText.text = "Score: " + playerInventory.NumberOfCoins;
                }

                StartCoroutine(FreezeEnemies());
            }
            else
            {
                Debug.Log("You need to collect the key first!");
            }
        }
    }
    private IEnumerator FreezeEnemies()
    {
        // Find and freeze all enemy GameObjects in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            UnityEngine.AI.NavMeshAgent enemyAgent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (enemyAgent != null)
            {
                enemyAgent.isStopped = true; // Stop the NavMeshAgent
            }
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(3f); // Adjust the time as needed

        // Unfreeze enemies
        foreach (GameObject enemy in enemies)
        {
            UnityEngine.AI.NavMeshAgent enemyAgent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (enemyAgent != null)
            {
                enemyAgent.isStopped = false; // Resume the NavMeshAgent
            }
            // Add any other enemy-specific unfreezing logic as needed
        }

        // Load the next scene
        LoadNextScene();
    }



    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level 2");
    }
}

