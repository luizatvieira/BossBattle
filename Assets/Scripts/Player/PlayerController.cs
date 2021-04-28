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
    private PlayerFire playerFire;

    [Header("Movement")]
    private Rigidbody rb;
    private Vector2 movementVector;

    [Header("Animation")]
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        playerDash = GetComponent<PlayerDash>();
        playerFire = GetComponent<PlayerFire>();
    }
    
    private void OnMove( InputValue movementValue )
    {
        movementVector = movementValue.Get<Vector2>();
        playerMovement.isWalking = true;
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

    private void OnFire()
    {
        playerFire.Shoot();
    }

    private void HandleAnimations()
    {
        animator.SetBool("isWalking", playerMovement.isWalking);
        //animator.SetBool("isFalling", !playerJump.isGrounded);
        //animator.SetBool("isJumping", playerJump.isJumping);
        //animator.SetBool("isDashing", playerDash.isDashing);
    }

    // FixedUpdate is called once per fixed frame (used for physics calculations)
    void FixedUpdate()
    {
        playerMovement.Move( movementVector, rb );
        playerJump.Jump( playerJump.jumpRequest );
    }

    void Update()
    {
        HandleAnimations();
    }
}
