using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerCamera : MonoBehaviour
{
    [SerializeField] Transform playerCameraRoot;


    private void Awake()
    {
        GameObject virtualCamera = GameObject.Find("PlayerFollowCamera");
        virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = playerCameraRoot;
    }
}
