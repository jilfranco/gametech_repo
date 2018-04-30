using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGlow : MonoBehaviour
{
	void Update()
	{
		float xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		float yPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		transform.position = new Vector3(xPos, yPos, 0);

	}
}
