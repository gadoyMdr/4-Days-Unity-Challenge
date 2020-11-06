using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovements))]
public class Crouch : MonoBehaviour
{
    [SerializeField] private float energyUsedPerCrouch;
    private Rigidbody2D _rigidbody2D;
    private PlayerMovements _playerMovements;
    private Energy _energy;

    private bool IsCrouched;
    public bool isCrouched
    {
        get => IsCrouched;
        set => IsCrouched = value;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovements = GetComponent<PlayerMovements>();
        _energy = GetComponent<Energy>();
    }

    private void FixedUpdate()
    {
        if (isCrouched)
        {
            if (_energy != null)
            {
                if (_energy.UseEnergy(energyUsedPerCrouch))
                {
                    ChangePlayerStatsToCrouched();
                }
                else
                {
                    ChangePlayerStatsToNormal();
                }
            }
            else
            {
                ChangePlayerStatsToCrouched();
            }
        }
        else
        {
            ChangePlayerStatsToNormal();
            
        }
    }

    public void ToggleCrouch()
    {
        
        isCrouched = !isCrouched;
        
    }

    void ChangePlayerStatsToCrouched()
    {
        _playerMovements.currentPlayerSpeed = _playerMovements.crouchedPlayerSpeed;
        _rigidbody2D.mass = _playerMovements.crouchedPlayerMass;
        transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.y);
    }

    void ChangePlayerStatsToNormal()
    {
        _playerMovements.currentPlayerSpeed = _playerMovements.basePlayerSpeed;
        _rigidbody2D.mass = _playerMovements.basePlayerMass;
        transform.localScale = Vector3.one;
    }
}
