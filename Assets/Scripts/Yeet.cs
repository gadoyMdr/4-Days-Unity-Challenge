using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Yeet : MonoBehaviour
{
    public delegate void HitEvent();
    public event HitEvent hitEvent;

    private float Yeetage;
    public float yeetage
    {
        get => Yeetage;
        set
        {
            Yeetage = value;
            UpdateYeetText();
        }
    }

    public bool isDead = false;

    [SerializeField]
    private TextMeshProUGUI yeetText;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        UpdateYeetText();
    }

    public void TakeHit(float amount, Vector3 from)
    {
        TakeDamage(amount);
        Expulse(from);
    }

    public void TakeDamage(float amount)
    {
        yeetage += amount;
        hitEvent?.Invoke();
    }

    void UpdateYeetText()
    {
        yeetText.text = $"Yeet : {yeetage.ToString("F1")} %";
    }

    void Expulse(Vector3 from)
    {
        Vector2 expulseVector = (transform.position - from).normalized;
        _rigidbody.AddForce(expulseVector * yeetage, ForceMode2D.Impulse);
    }
}
