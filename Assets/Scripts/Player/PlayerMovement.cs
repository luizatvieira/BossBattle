using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float movementSpeed = 1;

    public void Move ( Vector2 movementVector, Rigidbody rb ) {
        Vector3 movement = new Vector3( movementVector.x, 0.0f, movementVector.y );
        rb.AddForce( movement * movementSpeed );
    }
}