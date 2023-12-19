using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentScore : MonoBehaviour
{
    public static PersistentScore Instance { get; private set; }
    public int CurrentScore { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void AddScore(int amount)
    {
        CurrentScore += amount;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}

