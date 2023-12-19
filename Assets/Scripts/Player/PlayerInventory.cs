using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public AudioSource coinSoundEffect;
    public AudioSource keySoundEffect;

    public int NumberOfCoins { get; private set; }
    public bool HasKey { get; private set; } // New property to track key possession

    public UnityEvent<PlayerInventory> OnCoinCollected;
    public UnityEvent OnKeyCollected; // New event for key collection

    public void CoinCollected()
    {
        coinSoundEffect.Play();
        NumberOfCoins++;
        OnCoinCollected.Invoke(this);
    }

    public void KeyCollected() 
    {
        keySoundEffect.Play();
        HasKey = true;
        OnKeyCollected.Invoke();
    }


}

