using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Mine : MonoBehaviour
{
    [SerializeField]
    private float explosionRange;

    [SerializeField]
    private float explosionYeetDamage;

    [SerializeField]
    private float explosionKnockback;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger && !collision.tag.Equals("IgnoreCanJumpTrigger") || collision.name.Equals("Player"))
            Explode();
    }

    void Explode()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRange).DistinctBy(x => x.name).ToArray();

        foreach (Collider2D hitCollider in hitColliders)
        {
            float multi = 1 - Vector3.Distance(hitCollider.transform.position, transform.position) / explosionRange;
            Vector2 force = hitCollider.transform.position - transform.position;

            if (hitCollider.TryGetComponent(out Yeet yeet)) yeet.TakeHit(explosionYeetDamage * multi, transform.position);
            else if (hitCollider.TryGetComponent(out Rigidbody2D rb)) rb.AddForce(force * multi * explosionKnockback, ForceMode2D.Impulse);

            StartCoroutine(WaitToDestroy());
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(0.02f);
        Destroy(gameObject);
    }

    
}
