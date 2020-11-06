using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Die))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class LevelObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private PlanName planName;

    [SerializeField]
    private bool randomSize;

    [SerializeField]
    private bool randomSpeed;


    public bool fixedY;


    public bool randomY;


    public float minNextSpawnTime = 2;

    private float speed;

    private Plan plan;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GetPlan();

        speed = ParametersSingleton.instance.speed * plan.speedMultiplier;

        if (randomSize) SetRandomSize();
        if (randomSpeed) speed = speed.BeRandom(0.3f);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
    }

    void SetRandomSize()
    {
        float randomFloat = transform.localScale.x.BeRandom(0.4f);
        transform.localScale = new Vector3(randomFloat, randomFloat, randomFloat);
    }

    //Could've used Custom attributes and reflexion but not worth considering the due date
    void GetPlan()
    {
        switch (planName)
        {
            case PlanName.FarPlan :
                plan = Plan.farPlan;
                break;
            case PlanName.FirstPlan:
                plan = Plan.firsPlan;
                break;
            case PlanName.SecondPlan:
                plan = Plan.secondPlan;
                break;
        }
    }
}

public static class MyExtensions
{
    public static float BeRandom(this float number, float offSet)
    {
        return Random.Range(number * (1 - offSet), number * (1 + offSet));
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>
    (this IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector)
    {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            if (seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }
}
