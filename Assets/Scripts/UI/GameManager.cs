using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool instanceExists = false;

    void Awake()
    {
        if (instanceExists)
        {
            Destroy(gameObject); // Destroy if an instance already exists
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Persist this instance
            instanceExists = true;
        }
    }
}
