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


    [Header("Visual Shifts")]
    [SerializeField] private GameObject flipableComponents;
    [SerializeField] private CinemachineHandler cinemachineHandler;

    [Header("Movement")]
    private Rigidbody rb;
    private Vector2 movementVector;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //animator = flipableComponents.GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        playerDash = GetComponent<PlayerDash>();
        playerFire = GetComponent<PlayerFire>();
    }
    
    private void OnMove( InputValue movementValue )
    {
        movementVector = cinemachineHandler.AdaptMoveToCurrentCam(movementValue.Get<Vector2>());
        FlipPlayer( movementVector.x );
    }

    private void OnJump()
    {
        playerJump.jumpRequest = true;
    }

    private void OnDash()
    {
        if ( playerDash.canDash )
            StartCoroutine( playerDash.Dash( movementVector ) );
    }

    private void OnFire()
    {
        playerFire.Shoot();
    }

    private void HandleAnimations()
    {
        animator.SetBool("isWalking", playerMovement.isWalking);
        //animator.SetBool("isFalling", !playerJump.isGrounded);
        animator.SetBool("isJumping", playerJump.isJumping);
        //animator.SetBool("isDashing", playerDash.isDashing);
    }

    private void FlipPlayer( float direction )
    {
        if ( direction == 0 )
        {
            return;
        }
        if (direction > 0)
        {
            flipableComponents.transform.eulerAngles = cinemachineHandler.FlipObjectToCurrentCam(new Vector3 (0, 0, 0));
            return;
        }
       flipableComponents.transform.eulerAngles = cinemachineHandler.FlipObjectToCurrentCam(new Vector3 (0, 180, 0));
       return;

    }

    // FixedUpdate is called once per fixed frame (used for physics calculations)
    void FixedUpdate()
    {
        playerMovement.Move( movementVector, rb );
        playerJump.Jump( playerJump.jumpRequest );
    }

    void Update()
    {
        if ( movementVector.x != 0 || movementVector.y != 0 ) 
        {
            playerMovement.isWalking = true;
        } 
        else
        {
            playerMovement.isWalking = false;
        }
        HandleAnimations();
    }
}
