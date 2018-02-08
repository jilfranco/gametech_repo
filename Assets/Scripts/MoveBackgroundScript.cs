using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundScript : MonoBehaviour
{
	[SerializeField] private GameObject clouds;
	[SerializeField] private GameObject moon;
	[SerializeField] private float xMoveAmountClouds;
	[SerializeField] private float yMoveAmountClouds;
	[SerializeField] private float xMoveAmountMoon;
	[SerializeField] private float yMoveAmountMoon;
	[SerializeField] private float ySpeedClouds;
	[SerializeField] private float ySpeedMoon;

	private Rigidbody2D cloudsRB2D;
	private Rigidbody2D moonRB2D;
	private float xMoveClouds;
	private float yMoveClouds;
	private float xMoveMoon;
	private float yMoveMoon;

	private void Start()
	{
		cloudsRB2D = clouds.GetComponent<Rigidbody2D>();
		moonRB2D = moon.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		CheckInput();
		MoveBackground();
	}

	private void CheckInput()
	{
		xMoveClouds = Input.GetAxis("Horizontal") * -xMoveAmountClouds; // these values are negative to
		yMoveClouds = Input.GetAxis("Vertical") * -yMoveAmountClouds;   // make the paralax feel better
		xMoveMoon = Input.GetAxis("Horizontal") * -xMoveAmountMoon;
		yMoveMoon = Input.GetAxis("Vertical") * -yMoveAmountMoon;
	}

	private void MoveBackground()
	{
		Vector2 newVelocityClouds = new Vector2(xMoveClouds, yMoveClouds - ySpeedClouds);
		Vector2 newVelocityMoon = new Vector2(xMoveMoon, yMoveMoon - ySpeedMoon);
		cloudsRB2D.velocity = newVelocityClouds;
		moonRB2D.velocity = newVelocityMoon;
	}
}
