using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpirit : Weapon
{
    protected override void Start()
    {
        base.Start();
        damage = 50;
    }

    protected override void Update()
    {
        // Override base.Update to prevent automatic attack logic
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0f)
        {
            StartCoroutine(SpawnCycle());
            currentCooldown = cooldownDuration; // Reset cooldown to avoid multiple coroutine starts
        }
    }

    private IEnumerator SpawnCycle()
    {
        for (int i = 0; i < 4; i++)
        {
            Attack();
            yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds between each spawn
        }

        yield return new WaitForSeconds(10f); // Wait for 5 seconds before the next cycle
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject spirit = Instantiate(prefab, player.transform.position, Quaternion.identity);
        SpiritBehaviour spiritBehaviour = spirit.GetComponent<SpiritBehaviour>();

    }
}
