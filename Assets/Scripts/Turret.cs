using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Turret : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private float range;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private Transform barrelPivot;

    [SerializeField]
    private Transform barrelMuzzle;

    private Transform objectToTrack;
    private float timer;

    private void Awake()
    {
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager != null) objectToTrack = playerManager.transform;
    }

    private void Start()
    {
        RandomStats();
    }

    void Update()
    {
        if (CheckIfObjectInRange() && !CheckIfAnythingInBetween())
        {
            Focus();
            Fire();
        }
    }

    void RandomStats()
    {
        range = range.BeRandom(0.3f);
        fireRate = fireRate.BeRandom(0.3f);
    }

    void Focus()
    {
        Vector2 direction = transform.position - objectToTrack.position;

        barrelPivot.rotation = Quaternion.LookRotation(
                       Vector3.forward,
                       direction
                     );
    }

    void Fire()
    {
        if(Time.time > timer + fireRate)
        {
            Instantiate(projectile, barrelMuzzle.position, barrelMuzzle.rotation).Fire();
            timer = Time.time;
        }
        
    }

    bool CheckIfAnythingInBetween()
    {
        return Physics2D.LinecastAll(barrelMuzzle.position, objectToTrack.position).Any(x => x.collider.gameObject.tag.Equals("Enemy"));   
    }

    bool CheckIfObjectInRange()
    {
        if (objectToTrack != null)
            return Vector3.Distance(objectToTrack.position, transform.position) < range;
        else
            return false;
    }

    
}
