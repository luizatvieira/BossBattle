using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed; 
    private Rigidbody rb;

    public void SetTarget ( String tag ) 
    {
        target = GameObject.FindGameObjectWithTag( tag ).transform;
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( target != null )
        {
            transform.position = Vector3.MoveTowards( transform.position, target.position, Time.deltaTime * speed );
        }
        // else 
        // {
        //     rb.velocity = transform.right * speed;
        // }
    }

    void OnTriggerEnter( Collider hitInfo )
    {
        Destroy( gameObject );
    }
}
