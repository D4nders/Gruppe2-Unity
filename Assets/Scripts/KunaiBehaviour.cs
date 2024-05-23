using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiBehaviour : ProjectileWeaponBehaviour
{
    WeaponKunai wk;

    protected override void Start()
    {
        base.Start();
        wk = FindObjectOfType<WeaponKunai>();
    }

    private void Update()
    {
        transform.position += direction * wk.speed * Time.deltaTime;
    }
}
