using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float directionX = direction.x;
        float directionY = direction.y;

        float angle = (Mathf.Atan2(directionY, directionX) * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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
