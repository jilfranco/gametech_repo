using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaserScript : MonoBehaviour
{
	// laser longevity variables
    private float laserLifeLength = 1f;
	private float laserLifeCurrent = 0f;

	private void Start()
	{
		GetComponent<Rigidbody2D>().AddForce(transform.up * 600);
	}

	private void Update()
	{
		CheckCurrentLife();
	}

	private void CheckCurrentLife()
	{
		laserLifeCurrent += Time.deltaTime;
		if (laserLifeCurrent >= laserLifeLength)
			Destroy(gameObject);
	}
}
