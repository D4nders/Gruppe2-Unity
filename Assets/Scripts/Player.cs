using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float speed = 5f; // Movement speed
    public Vector2 movementDirection; // Direction
    private Rigidbody2D rb;
    private Animator animator;

    public UIScript uiScript;
    [SerializeField] AnimationCurve experienceCurve;
    public int currentLevel = 1;
    private int totalExp;
    private int previousLevelExp;
    private int nextLevelExp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exp"))
        {
            Experience orb = other.GetComponent<Experience>();
            if (orb != null)
            {
                AddExp(orb.expValue);
                Destroy(other.gameObject);
            }
        }
    }

    public void AddExp(int amount)
    {
        totalExp += amount;
        CheckForLevelUp();
        uiScript.UpdateExpBar(totalExp, previousLevelExp, nextLevelExp);
    }

    private void CheckForLevelUp()
    {
        while (totalExp >= nextLevelExp) // while-løkke for å håndtere flere nivåopprykk på en gang
        {
            currentLevel++;
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        previousLevelExp = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelExp = (int)experienceCurve.Evaluate(currentLevel + 1);
        uiScript.UpdateLevelText(currentLevel);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int health;
    public int totalHealth = 100;

    public void TakeDamage(int damage)
    {
        Debug.Log("Player took damage: " + damage);
        health -= damage;
        health = Mathf.Clamp(health, 0, totalHealth);
        uiScript.UpdateHealthBar(totalHealth, health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = 100;
        uiScript.UpdateHealthBar(totalHealth, health);

        UpdateLevel();
        uiScript.UpdateExpBar(totalExp, previousLevelExp, nextLevelExp);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontalInput, verticalInput).normalized;
        if (movementDirection.x != 0 || movementDirection.y != 0)
        {
            animator.SetFloat("X", movementDirection.x);
            animator.SetFloat("Y", movementDirection.y);

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        rb.velocity = movementDirection * speed;
    }
}
