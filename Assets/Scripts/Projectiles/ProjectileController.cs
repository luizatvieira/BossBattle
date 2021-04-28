using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //public Transform target;
    [SerializeField] private float speed; 
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
        //rb.MovePosition( new Vector3(0,4f,0) /*target.position*/ * Time.deltaTime * speed );
    }

    void OnTriggerEnter( Collider hitInfo )
    {
        Destroy( gameObject );
    }
}
