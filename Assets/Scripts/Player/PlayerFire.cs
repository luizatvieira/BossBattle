using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;

    public void Shoot () 
    {
        Instantiate( projectile, firePoint.position, firePoint.rotation );
    }
}
