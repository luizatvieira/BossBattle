using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineHandler : MonoBehaviour
{
    private CinemachineSwitcher cinemachineSwitcher;
    [SerializeField] private Transform[] flibableObjects;

    void Awake()
    {
        cinemachineSwitcher = GetComponent<CinemachineSwitcher>();
    }

    public Vector2 AdaptMoveToCurrentCam( Vector2 movementVector )
    {
        if ( cinemachineSwitcher.isFrontCamOn )
        {
            return movementVector;
        }
        else if ( cinemachineSwitcher.isLeftCamOn )
        {
            return new Vector2(
                movementVector.y,
                -movementVector.x
            );
        } 
        else
        {
            return new Vector2(
                -movementVector.y,
                movementVector.x
            );
        }
    }

    //Flips only the objects that need flipping (such as the player and the enemy)
    public void FlipAllObjectsToCurrentCam()
    {
        foreach ( Transform obj in flibableObjects )
        {
            obj.transform.eulerAngles = FlipObjectToCurrentCam( new Vector3 (0, 0, 0) );
        }
    }

    public Vector3 FlipObjectToCurrentCam( Vector3 rotation )
    {
        if ( !cinemachineSwitcher.isFrontCamOn )
        {
            return new Vector3(
                rotation.x,
                rotation.y+90,
                rotation.z
            );
        }
        return rotation;
    }
}
