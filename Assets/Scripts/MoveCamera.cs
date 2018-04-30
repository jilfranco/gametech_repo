using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	void Start()
	{
		transform.position = new Vector3(0,0,-10);
	}

	void Update()
	{
		Vector3 currentPos = transform.position;
		currentPos.z = -10;
		Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPos.z = -10;

		if (targetPos.y > 0.4f)
			targetPos.y = 0.4f;
		if (targetPos.y < -0.4f)
			targetPos.y = -0.4f;
		if (targetPos.x < -0.65f)
			targetPos.x = -0.65f;
		if (targetPos.x > 0.65f)
			targetPos.x = 0.65f;

		transform.position = Vector3.Lerp(currentPos, targetPos, 0.25f * Time.deltaTime);
		//transform.position = 
	}

}
