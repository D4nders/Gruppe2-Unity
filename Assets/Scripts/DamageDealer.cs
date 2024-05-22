using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    private float lastDamageTime = 0f;
    public float damageInterval = 0.3f;
    public void DamagePlayer(int damage)
    {
        if (Time.time - lastDamageTime >= damageInterval)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
                lastDamageTime = Time.time;
            }
            else
            {
                Debug.LogWarning("Player object not found!");
            }
        }
    }
}
