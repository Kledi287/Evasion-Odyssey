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
                UpdateScoreText(playerInventory.NumberOfCoins);
            }

            gameObject.SetActive(false);
        }
    }

    private void UpdateScoreText(int currentScore)
    {
        if (scoreText != null && scoreText.gameObject.activeInHierarchy)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }

}
