using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public void Setup()
    {
        gameObject.SetActive(true);

        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if (scoreText != null && playerInventory != null)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Score: " + playerInventory.NumberOfCoins;
        }
    }
}
