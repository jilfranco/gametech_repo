using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagic : MonoBehaviour
{
	[SerializeField] private float mouseHitCircle;
	[SerializeField] private MagicType magicColor;

	private Rigidbody2D magicRB;
	private Collider2D magicCollider;

	private float moveSpeedX, moveSpeedY;

	private bool isBeingDragged;

	void Start()
	{
		isBeingDragged = false;
		magicRB = GetComponent<Rigidbody2D>();
		magicCollider = GetComponent<Collider2D>();

		moveSpeedX = Random.Range(1.0f, 1.5f);
		moveSpeedY = Random.Range(-1.0f, 1.0f);

		StartCoroutine(RandomlyAdjustSpeed());
	}

	private IEnumerator RandomlyAdjustSpeed()
	{
		while (true)
		{
			float currentTime = 0.0f;
			float randomLengthOfTime = Random.Range(0.1f, 0.6f);
			float newRandomSpeedX = Random.Range(0.3f, 2.0f);
			float newRandomSpeedY = Random.Range(-1.2f, 1.5f);

			while (currentTime < randomLengthOfTime)
			{
				float progress = currentTime / randomLengthOfTime;

				moveSpeedX = Mathf.Lerp(moveSpeedX, newRandomSpeedX, progress);
				moveSpeedY = Mathf.Lerp(moveSpeedY, newRandomSpeedY, progress);
				currentTime += Time.deltaTime;
				
				yield return new WaitForEndOfFrame();
			}
		}
	}

	void Update()
	{
		if (isBeingDragged)
		{
			Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = newPosition;
			//Debug.Log("Follow the mouse here!");
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
						break;
					case MagicType.Blue:
						GameManager.gameManagerInstance.blueCollected++;
						break;
					case MagicType.Green:
						GameManager.gameManagerInstance.greenCollected++;
						break;
				}
			}
			// make a cauldron script
			// collision.GetComponent<Cauldron>()
			// give the cauldron a public "MagicType"
			// see if they match
		}
	}
}
