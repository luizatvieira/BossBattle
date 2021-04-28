using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float movementSpeed = 1;

    public void Move ( Vector2 movementVector, Rigidbody rb ) {
        Vector3 movement = new Vector3( 
            movementVector.x * movementSpeed, 
            rb.velocity.y, 
            movementVector.y *movementSpeed 
        );
        //rb.AddForce( movement * movementSpeed );
        rb.velocity = movement;
    }
}