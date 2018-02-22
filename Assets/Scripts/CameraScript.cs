using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public Transform target;
	public float followSpeed;

	private float zPos;

	void Start()
	{
		zPos = transform.position.z;
	}

	void FixedUpdate()
	{
		MoveCamera();
	}

	private void MoveCamera()
	{
		Vector3 newPos = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);
		newPos.z = zPos;
		transform.position = newPos;
	}
}
