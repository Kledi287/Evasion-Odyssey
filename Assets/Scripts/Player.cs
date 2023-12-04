using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public int currentHealth = 100;
    public float normalDamageCooldown = 2f;
    private float deathDamageCooldown = 100f; 
    private float currentDamageCooldown;
    private bool canTakeDamage = true;

    void Start()
    {
        currentDamageCooldown = normalDamageCooldown;
    }

    void Update()
    {
    
    }

    public void TakeDamage(int damageAmount)
    {
        if (canTakeDamage)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                currentDamageCooldown = deathDamageCooldown;
            }

            if (currentHealth <= 0 && currentDamageCooldown == deathDamageCooldown)
            {
                animator.SetTrigger("die");
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
}
