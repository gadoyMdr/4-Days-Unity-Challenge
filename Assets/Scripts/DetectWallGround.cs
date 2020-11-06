using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



[RequireComponent(typeof(Collider2D))]
public class DetectWallGround : MonoBehaviour
{
    public delegate void HasHitGroundOrWalls();
    public static event HasHitGroundOrWalls hasHitGroundOrWalls;

    public bool IsInContactWithGroundOrWalls;
    public bool isInContactWithGroundOrWalls
    {
        get => IsInContactWithGroundOrWalls;
        set
        {
            IsInContactWithGroundOrWalls = value;
            if (value)
            {
                hasHitGroundOrWalls?.Invoke();
            }
        }
    }


    private List<Collider2D> colliderList = new List<Collider2D>();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!colliderList.Contains(collision))
        {
            colliderList.Add(collision);
            CheckIfInContactWithWallsOrGround();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (colliderList.Contains(collision))
        {
            colliderList.Remove(collision);
            CheckIfInContactWithWallsOrGround();
        }
    }

    void CheckForNull()
    {
        List<Collider2D> tempColliderList = new List<Collider2D>(colliderList);
        foreach (Collider2D c in tempColliderList)
        {
            if (c == null) colliderList.Remove(c);
        }
    }

    void CheckIfInContactWithWallsOrGround() 
    {
        CheckForNull();
        isInContactWithGroundOrWalls = colliderList.Any(x => !x.gameObject.tag.Contains("IgnoreCanJumpTrigger")); 
    }

    
}
