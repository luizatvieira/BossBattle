using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    private PlayerDash playerDash;

    [Header("Movement")]
    private Rigidbody rb;
    private Vector2 movementVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        playerDash = GetComponent<PlayerDash>();
    }
    
    private void OnMove( InputValue movementValue )
    {
        movementVector = movementValue.Get<Vector2>();
    }

    private void OnJump()
    {
        playerJump.jumpRequest = true;
    }

    private void OnDash()
    {
        if ( playerDash.canDash )
            StartCoroutine( playerDash.Dash() );
    }

    // FixedUpdate is called once per fixed frame (used for physics calculations)
    void FixedUpdate()
    {
        playerMovement.Move( movementVector, rb );
        playerJump.Jump( playerJump.jumpRequest );
    }
}
