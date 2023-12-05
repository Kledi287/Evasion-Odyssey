using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Image keyImage; // Reference to the Image component in the Canvas containing the key image

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
        // Enable the key image on the Canvas
        keyImage.enabled = true;
    }
}
