using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [Header("Priority Calculation")]
    [SerializeField] private Transform player;
    private Vector3 frontCamPosition;
    private Vector3 leftCamPosition;
    private Vector3 rightCamPosition;

    [Header("Virtual Cameras")]
    [SerializeField] private CinemachineVirtualCamera frontCam;
    [SerializeField] private CinemachineVirtualCamera leftCam;
    [SerializeField] private CinemachineVirtualCamera rightCam;

    [Header("Control")]
    public bool isFrontCamOn;
    public bool isLeftCamOn;

    // Start is called before the first frame update
    void Awake()
    {
        frontCamPosition = frontCam.GetComponent<Transform>().position;
        leftCamPosition = leftCam.GetComponent<Transform>().position;
        rightCamPosition = rightCam.GetComponent<Transform>().position;
    }

    void Start()
    {
        isFrontCamOn = true;
        isLeftCamOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //The closer, the higher the priority of the camera
        leftCam.Priority  = (int) (100 - Vector3.Distance(player.position, leftCamPosition));
        rightCam.Priority = (int) (100 - Vector3.Distance(player.position, rightCamPosition));
        frontCam.Priority = (int) (100 - Vector3.Distance(player.position, frontCamPosition));
    }

    public void OnCameraSwitch( ICinemachineCamera cam1, ICinemachineCamera cam2)
    {
        if ( (Object) cam1 == frontCam )
        {
            isFrontCamOn = true;
            isLeftCamOn = false;
        }
        else if ( (Object) cam1 == leftCam )
        {
            isFrontCamOn = false;
            isLeftCamOn = true;
        }
        else 
        {
            isFrontCamOn = false;
            isLeftCamOn = false;
        }
        Debug.Log(isFrontCamOn);
        Debug.Log(isLeftCamOn);
    }
}
