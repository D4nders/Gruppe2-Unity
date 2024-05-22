using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : Weapon
{
    public float destroyAfterSeconds;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedArrow = Instantiate(prefab);
        spawnedArrow.transform.position = transform.position; // Set position to parent position
        spawnedArrow.GetComponent<ArrowBehaviour>().DirectionChecker(player.movementDirection);
    }
}
