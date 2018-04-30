using System.Collections;
using UnityEngine;

public class MoveMagic : MonoBehaviour
{
	[SerializeField] private float mouseHitCircle;
	[SerializeField] private MagicType magicColor;

	private Collider2D magicCollider;

	private float moveSpeedX, moveSpeedY;

	private bool isBeingDragged;

	void Start()
	{
		isBeingDragged = false;
		
		// get stuff
		magicCollider = GetComponent<Collider2D>();


		//ranges of how randomly the magic pieces move at the start
		moveSpeedX = Random.Range(1.0f, 1.5f);
		moveSpeedY = Random.Range(-1.0f, 1.0f);

		StartCoroutine(RandomlyAdjustSpeed());
	}

	void Update()
	{
		if (isBeingDragged)
		{
			Vector2 currentPos = transform.position;
			Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = Vector3.Lerp(currentPos, targetPos, GameManager.gameManagerInstance.mouseSpeed);
		}

		else
		{
			Vector2 currentPos = transform.position;
			currentPos.x -= moveSpeedX * Time.deltaTime;
			currentPos.y += moveSpeedY * Time.deltaTime;
			transform.position = currentPos;
		}
	}

	private void OnMouseDown()
	{
		// Get the mouse position in world space
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Collider2D colliderMouseHit = Physics2D.OverlapCircle(mousePos, mouseHitCircle);
		if (colliderMouseHit != null && colliderMouseHit == magicCollider)
			isBeingDragged = true;

		// Do a Physics2D.OverlapCircle to see if the
		// circle around the pointer overlaps OUR collider
		// (you need to make sure it's THIS OBJECT's collider)

		// if it is, set isBeingDragged to true

		// check if the mouse is over this particular piece
		// use its collider, and Screen.MouseToWorld
		// set isBeingDragged to true if yes
	}

	private void OnMouseUp()
	{
		// isBeingDragged can ALWAYS be set to false here, because when the mouse button
		// is released, all dragging stops
		isBeingDragged = false;
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.CompareTag("KillSpot"))
		{
			Destroy(gameObject);
			GameManager.gameManagerInstance.activeMagicList.Remove(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var cauldron = collision.gameObject.GetComponent<Cauldron>();
		if (cauldron != null)
		{
			var cauldronColor = cauldron.cauldronMagicType;


			if (cauldronColor == magicColor)
			{
				isBeingDragged = false;
				Destroy(gameObject);
				switch (magicColor)
				{
					case MagicType.Red:
						GameManager.gameManagerInstance.redCollected++;
						GameManager.gameManagerInstance.activeMagicList.Remove(gameObject);
						break;
					case MagicType.Blue:
						GameManager.gameManagerInstance.blueCollected++;
						GameManager.gameManagerInstance.activeMagicList.Remove(gameObject);
						break;
					case MagicType.Green:
						GameManager.gameManagerInstance.greenCollected++;
						GameManager.gameManagerInstance.activeMagicList.Remove(gameObject);
						break;
				}
			}
		}
	}

	private IEnumerator RandomlyAdjustSpeed()
	{
		// we always want this to happen, so it's always true
		while (true)
		{
			// get the time for lerping. all of them have a random
			// time, so we give them a range
			float currentTime = 0.0f;
			float randomLengthOfTime = Random.Range(0.1f, 0.6f);

			// this is the range of how randomly the pieces move after
			// being modified
			float newRandomSpeedX = Random.Range(0.75f, 2.0f);
			float newRandomSpeedY = Random.Range(-1.2f, 1.2f);

			//this is how we do the random lerping
			while (currentTime < randomLengthOfTime)
			{
				// keep track of the current time against the random time to 
				// lerp the movements
				float progress = currentTime / randomLengthOfTime;

				moveSpeedX = Mathf.Lerp(moveSpeedX, newRandomSpeedX, progress);
				moveSpeedY = Mathf.Lerp(moveSpeedY, newRandomSpeedY, progress);
				
				// add the time passed to keep everything going
				currentTime += Time.deltaTime;
				
				yield return new WaitForEndOfFrame();
			}
		}
	}
}
