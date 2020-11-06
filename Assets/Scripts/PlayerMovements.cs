using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovements : MonoBehaviour
{
    #region STATS
    [Header("Player speed")]
    public float basePlayerSpeed = 2f;
    public float crouchedPlayerSpeed = 0.5f;
    public float currentPlayerSpeed;
    public float multi = 1f;

    [Header("Player mass")]
    public float basePlayerMass = 1f;
    public float crouchedPlayerMass = 2f;
    
    
    #endregion

    private Rigidbody2D _rigidbody;

    [HideInInspector]
    public float moveXSpeedInput = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentPlayerSpeed = basePlayerSpeed;
       _rigidbody.mass = basePlayerMass;
    }

    public void Update()
    {
        if (moveXSpeedInput != 0f) Move(moveXSpeedInput);
    }
    
    public void Move(float moveXSpeedInput)
    {
        _rigidbody.velocity = new Vector2
            (_rigidbody.velocity.x + moveXSpeedInput * currentPlayerSpeed * multi, 
            _rigidbody.velocity.y);
    }
}
