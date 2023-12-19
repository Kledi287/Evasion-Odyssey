using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Image keyImage; 
    public PlayerInventory playerInventory; 

    void Start()
    {
        keyImage.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {  
            CollectKey();
            gameObject.SetActive(false); 
        }
    }

    private void CollectKey()
    {
        keyImage.enabled = true;
        playerInventory.KeyCollected(); // Update the player's inventory to indicate key collection
    }
}
