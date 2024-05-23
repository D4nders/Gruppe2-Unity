using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponArrow : Weapon
{
    protected override void Start()
    {
        base.Start();
        damage = 100;
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedArrow = Instantiate(prefab);
        spawnedArrow.transform.position = transform.position; // Set position to parent position
        spawnedArrow.GetComponent<ArrowBehaviour>().SetDirection(player.lastMovedDirection);
    }
}
