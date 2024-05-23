using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : ProjectileWeaponBehaviour
{
    WeaponArrow wa;
    protected override void Start()
    {
        base.Start();
        wa = FindObjectOfType<WeaponArrow>();
        music.PlayFireArrow();
    }

    void Update()
    {
        transform.position += direction * wa.speed * Time.deltaTime;
    }
}
