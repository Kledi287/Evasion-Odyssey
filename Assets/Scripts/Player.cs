using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public float damageCooldown = 2f;
    private int currentHealth;
    private bool canTakeDamage = true;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        DamageCooldown();
    }

    public void TakeDamage(int damageAmount)
    {
        if (canTakeDamage)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                Debug.Log("Player is triggering die animation.");
                animator.SetTrigger("die");
            }

            Debug.Log("Player took damage. Current health: " + currentHealth);

            // Start the damage cooldown coroutine
            StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    } 
}
