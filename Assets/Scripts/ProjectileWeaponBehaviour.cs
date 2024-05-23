using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;
    protected MusicController music;

    protected virtual void Start()
    {
        music = FindObjectOfType<MusicController>();
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = targetRotation;
        transform.Rotate(0f, 0f, 90f);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy"))
        {
            Enemy enemy = collider2D.GetComponent<Enemy>();
            Weapon weapon = FindObjectOfType<Weapon>();
            enemy.TakeDamage(weapon.damage);
        }
    }
}
