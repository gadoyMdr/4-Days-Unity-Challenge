using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Controls _controls;
    private PlayerMovements playerMovements;
    private Crouch playerCrouch;
    private Jump playerJump;
    private GameManager gameManager;
    private void Awake()
    {
        _controls = new Controls();
        playerMovements = FindObjectOfType<PlayerMovements>();
        playerCrouch = playerMovements.GetComponent<Crouch>();
        playerJump = playerMovements.GetComponent<Jump>();
        gameManager = FindObjectOfType<GameManager>();


        if (playerCrouch != null)
        {
            _controls.Player.Crouch.performed += _ => playerCrouch.ToggleCrouch();
            _controls.Player.Crouch.canceled += _ => playerCrouch.ToggleCrouch();
        }
        if(playerMovements != null)
        {
            _controls.Player.Left.performed += _ => playerMovements.moveXSpeedInput = -1f;
            _controls.Player.Left.canceled += _ => playerMovements.moveXSpeedInput = 0;
            _controls.Player.Right.performed += _ => playerMovements.moveXSpeedInput = 1f;
            _controls.Player.Right.canceled += _ => playerMovements.moveXSpeedInput = 0;
        }
        if(playerJump != null)
        {
            _controls.Player.Jump.performed += _ => playerJump.TryJump();
        }

        if(gameManager != null)
        {
            _controls.Others.RestartGame.performed += _ => gameManager.RestartGame();
        }

        
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
        _controls.Others.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
        _controls.Others.Disable();
    }
}
