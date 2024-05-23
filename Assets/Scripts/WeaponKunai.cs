using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKunai : Weapon
{
    protected override void Start()
    {
        base.Start();
        damage = 100;
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedKunai = Instantiate(prefab);
        spawnedKunai.transform.position = transform.position;

        // Find nearest enemy
        Enemy nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            // Calculate direction towards enemy
            Vector3 directionToEnemy = (nearestEnemy.transform.position - spawnedKunai.transform.position).normalized;
            spawnedKunai.GetComponent<KunaiBehaviour>().SetDirection(directionToEnemy);
        }
        else
        {
            // If no enemy, default to player's direction
            spawnedKunai.GetComponent<KunaiBehaviour>().SetDirection(player.lastMovedDirection);
        }
    }

    private Enemy FindNearestEnemy()
    {
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in allEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
