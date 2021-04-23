using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour 
{
    [Header("Control")]
    public bool jumpRequest;
    public bool isGrounded;
    public bool isJumping;
    public bool doubleJump;

    [Header("Physics")]
    private Rigidbody rb;
    [SerializeField] private float jumpSpeed;
    //[SerializeField] private float fallSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isGrounded = false;
        isJumping = false;
        jumpRequest = false;
        doubleJump = true;
    }

    public void Jump( bool request )
    {
        if( request && (isGrounded || doubleJump) )
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);

            if( isJumping )
                doubleJump = false;
            else
                isJumping = true;
        }
        jumpRequest = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        isJumping = false;
        doubleJump = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
       isGrounded = false;
    }

    //Not sure if I want to add this or not yet...
    /*public void HandleFall()
    {
        //Makes the fall cooler and faster
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * fallSpeed, ForceMode.Impulse);
            isJumping = false;
        }
    }*/
}