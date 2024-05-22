using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicEnemy : Enemy
{
    private NavMeshAgent agent;
    private Animator animator;
    public Vector2 playerPosition;

    private void Start()
    {
        totalHealth = 100;
        health = totalHealth;
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
            playerPosition = player.transform.position;
            agent.SetDestination(playerPosition);
            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        // Calculate direction vector
        Vector2 position = transform.position;
        Vector2 direction = (playerPosition - position).normalized;

        // Set animator parameters
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }

    public int damage = 5; // Damage the enemy inflicts on the player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collided with something: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Player");
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
