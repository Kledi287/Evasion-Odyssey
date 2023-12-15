using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public Animator animator;
    public Slider healthBar;
    public int currentHealth = 100;
    public float normalDamageCooldown = 2f;
    private float deathDamageCooldown = 100f; 
    private float currentDamageCooldown;
    private bool canTakeDamage = true;

    void Start()
    {
        healthBar.value = currentHealth;
        currentDamageCooldown = normalDamageCooldown;
    }

    void Update()
    {
    
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void TakeDamage(int damageAmount)
    {
        if (canTakeDamage)
        {
            currentHealth -= damageAmount;
            healthBar.value -= damageAmount;

            if (currentHealth <= 0)
            {
                currentDamageCooldown = deathDamageCooldown;
            }

            if (currentHealth <= 0 && currentDamageCooldown == deathDamageCooldown)
            {
                animator.SetTrigger("die");
                GameOver();
            }

            StartCoroutine(DamageCooldown());      
        }
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(currentDamageCooldown);
        canTakeDamage = true;
        currentDamageCooldown = normalDamageCooldown; // Reset to normal cooldown after waiting
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
    }
}
