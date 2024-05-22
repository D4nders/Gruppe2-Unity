using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SpiritBehaviour : ProjectileWeaponBehaviour
{
    WeaponSpirit ws;
    private float elapsedTime = 0f;
    public float orbitDistance = 2f;
    protected override void Start()
    {
        base.Start();
        ws = FindObjectOfType<WeaponSpirit>();

    }

    void Update()
    {
        // Calculate the new position
        float angle = elapsedTime * ws.speed;
        float radians = angle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * orbitDistance;

        Player player = FindObjectOfType<Player>();
        // Update the weapon's position
        transform.position = (Vector2)player.transform.position + offset;

        // Increment elapsed time
        elapsedTime += Time.deltaTime;
    }
}
