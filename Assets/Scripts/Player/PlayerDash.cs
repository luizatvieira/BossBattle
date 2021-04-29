using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour 
{
    public GameObject dashEffect;

    [Header("Physics")]
    private Rigidbody rb;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashTime = 10f;
    [SerializeField] private float waitTime = 10f;

    [Header("Control")]
    public bool isDashing;
    public bool canDash;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        isDashing = false;
        canDash = true;
    }

    public IEnumerator Dash( Vector2 dashDirection )
    {
        isDashing = true;
        canDash = false;
        float rotation = (dashDirection.x*-90) + (dashDirection.y*180);
        Debug.Log(rotation);
        GameObject thisDash = Instantiate( 
            dashEffect, 
            transform.position, 
            Quaternion.Euler( 0f, rotation, 0f ) 
        );

        yield return new WaitForSeconds( dashTime );
        Destroy( thisDash );
        isDashing = false;
        rb.velocity = new Vector3(0.0f,0.0f,0.0f);

        yield return new WaitForSeconds( waitTime );
        canDash = true;
    }
    
    private void FixedUpdate()
    {
        if ( isDashing )
            rb.velocity = rb.velocity.normalized*dashSpeed;
    }
}