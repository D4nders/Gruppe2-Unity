using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected Player player;
    protected int health, totalHealth;
    protected MusicController music;

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    protected virtual void Awake()
    {
        music = FindObjectOfType<MusicController>();
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("No Player object found in the scene!");
        }
    }
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, totalHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        music.PlayEnemyKill();
        Destroy(gameObject); // Basic destruction logic
    }
}
