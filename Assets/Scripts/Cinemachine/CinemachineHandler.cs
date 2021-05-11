using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineHandler : MonoBehaviour
{
    private CinemachineSwitcher cinemachineSwitcher;

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
}
