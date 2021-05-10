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

    // Start is called before the first frame update
    void Start()
    {
        frontCamPosition = frontCam.GetComponent<Transform>().position;
        leftCamPosition = leftCam.GetComponent<Transform>().position;
        rightCamPosition = rightCam.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        //The closer, the higher the priority of the camera
        leftCam.Priority  = (int) (100 - Vector3.Distance(player.position, leftCamPosition));
        rightCam.Priority = (int) (100 - Vector3.Distance(player.position, rightCamPosition));
        frontCam.Priority = (int) (100 - Vector3.Distance(player.position, frontCamPosition));
    }
}
