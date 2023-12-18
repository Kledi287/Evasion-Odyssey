using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    public int damageAmount;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Adjust damage amount based on difficulty
        SetDifficultyParameters(animator);
    }

    private void SetDifficultyParameters(Animator animator)
    {
        // Retrieve the difficulty setting
        int difficulty = PlayerPrefs.GetInt(MainMenuScreen.DIFFICULTY_KEY, 1); // Default to Medium

        switch (difficulty)
        {
            case 0: // Easy
                damageAmount = 5;
                break;
            case 1: // Medium
                damageAmount = 10;
                break;
            case 2: // Hard
                damageAmount = 20;
                break;
        }
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);

        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance > 3.5f)
        {
            animator.SetBool("isAttacking", false);
        }
       else
        {
            // Call the TakeDamage method of the player when in range
            Player playerScript = player.GetComponent<Player>();

            if (playerScript != null)
            {
                playerScript.TakeDamage(damageAmount);
            }
        }

        // Adjust damage based on difficulty
        float difficulty = MainMenuScreen.GetDifficulty();
        if (difficulty == MainMenuScreen.EASY_DIFFICULTY)
        {
            damageAmount = 5;  // Example value for easy
            Debug.Log("5 damage taken");
        }
        else if (difficulty == MainMenuScreen.MEDIUM_DIFFICULTY)
        {
            damageAmount = 10;  // Example value for medium
            Debug.Log("10 damage taken");
        }
        else if (difficulty == MainMenuScreen.HARD_DIFFICULTY)
        {
            damageAmount = 20;  // Example value for hard
            Debug.Log("20 damage taken");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // You can add additional logic here if needed
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
