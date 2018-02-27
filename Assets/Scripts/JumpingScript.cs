using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour {

	public LayerMask ground;
	public Transform groundCheck;
	public Rigidbody2D playerRigidBody;
	public bool onGround;
	public float jumpForce;

	private bool shouldJump;

	private void Start()
	{
		playerRigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		CheckInput();
	}

	private void FixedUpdate()
	{
		CheckGround();
		CheckJump();
	}

	private void CheckInput()
	{
		if (Input.GetKeyDown(KeyCode.Space) && onGround)
			shouldJump = true;
	}

	private void CheckJump()
	{
		if (shouldJump)
			Jump();
	}

	private void Jump()
	{
		shouldJump = false;
		playerRigidBody.AddForce(Vector2.up * jumpForce);
	}

	private void CheckGround()
	{
		Collider2D playerCollider = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);

		if (playerCollider == null)
			onGround = false;
		else
			onGround = true;
	}
}
