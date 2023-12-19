using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Image keyImage; // Reference to the Image component in the Canvas containing the key image
    public PlayerInventory playerInventory; // Reference to the PlayerInventory component

    void Start()
    {
        keyImage.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {  
            CollectKey();
            gameObject.SetActive(false); // Deactivate the entire GameObject (optional)
        }
    }

    private void CollectKey()
    {
        keyImage.enabled = true;
        playerInventory.KeyCollected(); // Update the player's inventory to indicate key collection
    }
}
