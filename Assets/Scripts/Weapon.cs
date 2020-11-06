using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float yeetDamage = 2;

    [SerializeField]
    private float energyDamage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Yeet yeet))
        {
            yeet.TakeHit(yeetDamage, collision.contacts[0].point);
        }
        if (collision.gameObject.TryGetComponent(out Energy enemyEnergy))
        {
            enemyEnergy.UseEnergy(energyDamage, true);
        }
    }
}
