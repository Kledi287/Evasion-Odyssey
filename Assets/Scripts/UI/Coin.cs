using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    private static TextMeshProUGUI scoreText; // Static reference to the score text

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CoinCollected();
                // Notify the PersistentScore of the coin collection instead of directly updating the UI
                if (PersistentScore.Instance != null)
                {
                    PersistentScore.Instance.AddScore(1); // Assuming each coin is worth 1 point
                }
            }

            gameObject.SetActive(false);
        }
    }
}
