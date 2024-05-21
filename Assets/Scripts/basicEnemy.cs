using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicEnemy : Enemy
{
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null)
        {
            Debug.LogError("No NavMeshAgent component found on " + gameObject.name);
        }

        if (animator == null)
        {
            Debug.LogError("No Animator component found on " + gameObject.name);
        }

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (player != null)
        {
            // player is inherited from the parent class
            agent.SetDestination(player.position);
            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        // Calculate direction vector
        Vector2 direction = (player.position - transform.position).normalized;

        // Set animator parameters
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }
}
