using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DetectWallGround))]
public class Jump : MonoBehaviour
{
    [Header("Player jump force")]
    public float basePlayerJumpForce = 2f;

    [SerializeField]
    private int multiJump;

    [SerializeField]
    private int energyPerExtraJump = 20;

    private DetectWallGround _detectWallGround;
    private Rigidbody2D _rigidbody;
    private Energy _energy;
    private int jumpCount;

    private void Awake()
    {
        _detectWallGround = GetComponent<DetectWallGround>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _energy = GetComponent<Energy>();
    }

    private void OnEnable() => DetectWallGround.hasHitGroundOrWalls += ResetJumpCount;
    

    private void OnDisable() => DetectWallGround.hasHitGroundOrWalls -= ResetJumpCount;
    

    void ResetJumpCount()
    {
        jumpCount = 0;
    }

    public void TryJump()
    {
        if(multiJump > 0 && jumpCount < multiJump)
        {
            if (!_detectWallGround.isInContactWithGroundOrWalls)
            {
                if(_energy != null)
                {
                    if (_energy.UseEnergy(energyPerExtraJump))
                    {
                        ActuallyJump();
                        jumpCount++;
                    }
                }
                else
                {
                    ActuallyJump();
                    jumpCount++;
                }
            }
            else
            {
                ActuallyJump();
            }
        }
        else
        {
            if (_detectWallGround.isInContactWithGroundOrWalls)
                ActuallyJump();
        }

        
    }

    void ActuallyJump()
    {
        _rigidbody.AddForce(Vector2.up * basePlayerJumpForce, ForceMode2D.Impulse);
    }

}
