using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform cameraFollow;
    [SerializeField] private float followSpeed;

    private float cameraZPosition;

    private void Start()
    {
        cameraZPosition = transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 newCameraPosition = Vector3.Lerp(transform.position, cameraFollow.position, Time.deltaTime * followSpeed);
        newCameraPosition.z = cameraZPosition;
        transform.position = newCameraPosition;
    }
}
