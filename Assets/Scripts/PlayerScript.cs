using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	//player variables
    [SerializeField] private float playerHealth;
	private Rigidbody2D playerRb2D;

	// move variables
	[SerializeField] private float ySpeed;
	[SerializeField] private float xSpeed;
	private float xMove;
	private float yMove;

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
		Vector2 minBounds = Camera.main.ViewportToWorldPoint(Vector2.zero);
		Vector2 maxBounds = Camera.main.ViewportToWorldPoint(Vector2.one);

		Vector2 playerSize = new Vector2(0.85f, 0.49f);
		minBounds = minBounds + playerSize;
		maxBounds = maxBounds - playerSize;

		float newXPosition = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
		float newYPosition = Mathf.Clamp(transform.position.y, minBounds.y, minBounds.y + 2); // +2 is the up limit

		transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
	}

	private void SpawnLaser()
	{
		Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
	}
}
