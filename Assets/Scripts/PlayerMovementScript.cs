using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
	// move variables
	private float xMove;
	private float yMove;
	[SerializeField] private float xSpeed;
	[SerializeField] private float ySpeed;

	// bounds variables
	[SerializeField] private float boundsUp;
	[SerializeField] private float boundsDown;
	[SerializeField] private float boundsLeft;
	[SerializeField] private float boundsRight;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		CheckInput();
		MovePlayer();
	}

	private void LateUpdate()
	{
		CheckBounds();
	}

	private void CheckInput()
	{
		xMove = Input.GetAxis("Horizontal") * xSpeed;
		yMove = Input.GetAxis("Vertical") * ySpeed;
	}

	private void MovePlayer()
	{
		Vector2 newVelocity = new Vector2(xMove, yMove);
		rb.velocity = newVelocity;
	}

	private void CheckBounds()
	{
		float newX = Mathf.Clamp(transform.position.x, boundsLeft, boundsRight);
		float newY = Mathf.Clamp(transform.position.y, boundsDown, boundsUp);
		transform.position = new Vector3(newX, newY, transform.position.z);
	}
}
