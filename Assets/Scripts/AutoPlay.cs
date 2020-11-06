using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(Crouch))]
[RequireComponent(typeof(PlayerMovements))]
public class AutoPlay : MonoBehaviour
{
    private Jump _jump;
    private Crouch _crouch;
    private PlayerMovements _playerMovements;

    float jumpCoolDown = 0.5f;
    int layerMask = 1 << 8;
    bool canJump = true;

    private void Awake()
    {
        _jump = GetComponent<Jump>();
        _crouch = GetComponent<Crouch>();
        _playerMovements = GetComponent<PlayerMovements>();
    }

    private void Update()
    {
        CheckTopFront();
        CheckMiddleFront();
        CheckScreenPlacement();
    }

    void CheckScreenPlacement()
    {
        Vector2 cameraPlacement = Camera.main.WorldToScreenPoint(transform.position);
        if (cameraPlacement.x < Screen.width * 0.20f) _playerMovements.Move(1);
        if (cameraPlacement.x > Screen.width * 0.80f) _playerMovements.Move(-1);
    }

    void CheckTopFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y + 1), Vector2.right, 1f, layerMask);

        _crouch.isCrouched = hit.collider != null;
        
    }

    void CheckMiddleFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, layerMask);

        if (hit.collider != null && canJump)
        {
            _jump.TryJump();
            JumpCoolDownCoroutine();
        }
    }

    IEnumerator JumpCoolDownCoroutine()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCoolDown);
        canJump = true;
    }
}
