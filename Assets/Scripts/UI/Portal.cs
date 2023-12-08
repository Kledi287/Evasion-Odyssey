using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Tag for the player
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Check if the player has collected the key
            if (PlayerHasCollectedKey())
            {
                // Load the next scene
                LoadNextScene();
            }
            else
            {
                Debug.Log("You need to collect the key first!");
            }
        }
    }

    private bool PlayerHasCollectedKey()
    {
        // Find the Key script attached to the same GameObject
        Key keyScript = GetComponent<Key>();

        // Check if the key script is found
        if (keyScript != null)
        {
            // Check if the key image is enabled, indicating that the key has been collected
            return keyScript.keyImage.enabled;
        }
        else
        {
            // Key script not found, log an error or handle it as appropriate for your game
            Debug.LogError("Key script not found on the same GameObject as the Portal!");
            return false;
        }
    }


    private void LoadNextScene()
    {
        // Load the next scene (you can replace "NextScene" with the actual name of your next scene)
        SceneManager.LoadScene("Level 2");
    }
}

