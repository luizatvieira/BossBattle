using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour 
{
    public bool jumpRequest;
    [SerializeField] private float jumpSpeed;

    public void Jump( bool request, Rigidbody rb )
    {
        if(request)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);
            jumpRequest = false;
            //isJumping = true;
        }
    }
}