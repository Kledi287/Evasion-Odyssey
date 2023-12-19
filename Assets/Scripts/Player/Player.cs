using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource deathSoundEffect;
    public AudioSource hitSoundEffect;
    public GameOverScreen gameOverScreen;
    public Animator animator;
    public Slider healthBar;
    public int currentHealth = 100;
    public float normalDamageCooldown = 2f;
    private float deathDamageCooldown = 100f;
    private float currentDamageCooldown;
    private bool canTakeDamage = true;
    private bool isDead = false;

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
        if (canTakeDamage && !isDead) // Check if the player can take damage and is not dead
        {
            currentHealth -= damageAmount;
            healthBar.value = currentHealth;

            hitSoundEffect.Play();

            if (currentHealth <= 0)
            {
                if (!isDead) // Only trigger death once
                {
                    isDead = true; // Set the flag to true as the player is now dead
                    animator.SetTrigger("die");
                    deathSoundEffect.Play();   

                    // Assuming you have a PlayerInventory component attached to the same GameObject
                    PlayerInventory playerInventory = GetComponent<PlayerInventory>();

                    gameOverScreen.Setup(); // Pass the actual score to the Setup method
                }
            }
            else
            {
                StartCoroutine(DamageCooldown());
            }
        }
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(currentDamageCooldown);
        canTakeDamage = true;
        currentDamageCooldown = normalDamageCooldown; // Reset to normal cooldown after waiting
    }

}

