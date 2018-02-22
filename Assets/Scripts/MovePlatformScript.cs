using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformScript : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;

	private float platformSpeed;

	private void Start()
	{
		platformSpeed = GameManager.gameManagerInstance.platformMoveSpeed;
	}

	private void Update()
	{
		MovePlatform();
	}

	private void LateUpdate()
	{
		CheckBounds();
	}

	private void MovePlatform()
	{
		rb.AddForce(new Vector2(-1*platformSpeed, 0));
	}

	private void CheckBounds()
	{
		
	}
}
