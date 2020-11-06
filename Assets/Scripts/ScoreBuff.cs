using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBuff : MonoBehaviour
{
    private Score score;

    [SerializeField]
    private int scoreAmount;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player") && collision.isTrigger)
        {
            score.scoreCount += scoreAmount;
            Destroy(gameObject);
        }
    }

    
}
