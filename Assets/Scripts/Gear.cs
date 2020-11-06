using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Gear : MonoBehaviour
{
    [SerializeField] private List<Sprite> gears = new List<Sprite>();
    [SerializeField] private float minRadius;
    [SerializeField] private float maxRadius;
    [SerializeField] private float minRotateSpeed = 5;
    [SerializeField] private float maxRotateSpeed = 80;

    private float rotateSpeed;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = gears[Random.Range(0, gears.Count)];
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        GetRandomSize();
    }

    private void Update()
    {
        transform.Rotate(0, 0, 6.0f * rotateSpeed * Time.deltaTime);
    }

    void GetRandomSize()
    {
        float randomRadius = Random.Range(minRadius, maxRadius);
        transform.localScale = new Vector3(randomRadius, randomRadius, randomRadius);
        _circleCollider2D.radius = transform.localScale.x * 2;
    }

}
