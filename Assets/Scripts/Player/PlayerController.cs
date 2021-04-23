using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;

    [Header("Movement")]
    private Rigidbody rb;
    private Vector2 movementVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
    }
    
    private void OnMove( InputValue movementValue )
    {
        movementVector = movementValue.Get<Vector2>();
    }

    private void OnJump()
    {
        playerJump.jumpRequest = true;
    }

    // FixedUpdate is called once per fixed frame (used for physics calculations)
    void FixedUpdate()
    {
        playerMovement.Move( movementVector, rb );
        playerJump.Jump( playerJump.jumpRequest );
    }
}
