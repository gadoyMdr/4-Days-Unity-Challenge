using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class HitGround : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    private bool moveLeft = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ground")) moveLeft = true;
    }

    private void FixedUpdate()
    {
        if(moveLeft)
            _rigidbody.MovePosition(new Vector2(transform.position.x + ParametersSingleton.instance.speed, transform.position.y));
    }
}
