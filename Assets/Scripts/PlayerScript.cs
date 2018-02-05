using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	//player variables
	private Rigidbody2D playerRb2D;

	// move variables
	private float xMove;
	private float yMove;
	[SerializeField] private float xSpeed;
	[SerializeField] private float ySpeed;

	// laser variables
	[SerializeField] private GameObject laserPrefab;
	[SerializeField] private Transform laserSpawnPoint;
	
	private void Start()
	{
		playerRb2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		CheckInput();
		MovePlayer();
	}

	// late update to make sure it's the last thing it does
	private void LateUpdate()
	{
		CheckBounds();
	}

	// check input of arrow keys (movement) and spacebar (spawn laser)
	private void CheckInput()
	{
		xMove = Input.GetAxis("Horizontal") * xSpeed;
		yMove = Input.GetAxis("Vertical") * ySpeed;

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			SpawnLaser();
		}
	}

	private void MovePlayer()
	{
		Vector2 newVelocity = new Vector2(xMove, yMove);
		playerRb2D.velocity = newVelocity;
	}

	// set player movement bounds based on viewport aspect ratio
	private void CheckBounds()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
		Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

		Vector2 playerSize = new Vector2(0.68f, 0.49f);
		min = min + playerSize;
		max = max - playerSize;

		float newX = Mathf.Clamp(transform.position.x, min.x, max.x);
		float newY = Mathf.Clamp(transform.position.y, min.y, min.y + 2);
		transform.position = new Vector3(newX, newY, transform.position.z);
	}

	private void SpawnLaser()
	{
		Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
	}
}
