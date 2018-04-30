using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DebuffScript : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float slowTime;
	[SerializeField] private float debuffMouseSpeed;

	[SerializeField] private float mouseHitCircle;

	// a list of functions :0
	// <Action> for when it's a void with no params
	// <Action<paramType> for when it's a void with params
	// use (and google) Func<> for when it returns / returns w/ params
	private List<Action> functionsList;
	private List<Action> giveAmountsList;

	private bool isBeingDragged;
	private Collider2D debuffCollider;


	void Start()
	{
		// add current amounts from game manager to a list to be
		// randomly selected to be added to

		functionsList = new List<Action>();
		giveAmountsList = new List<Action>();

		functionsList.Add(RemoveAmount);
		functionsList.Add(RemoveTime);
		functionsList.Add(SlowDownMouse);

		giveAmountsList.Add(RemoveAmountRed);
		giveAmountsList.Add(RemoveAmountBlue);
		giveAmountsList.Add(RemoveAmountGreen);

		debuffCollider = GetComponent<Collider2D>();

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
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}
		
	}

	private void OnMouseDown()
	{
		// Get the mouse position in world space
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Collider2D colliderMouseHit = Physics2D.OverlapCircle(mousePos, mouseHitCircle);
		if (colliderMouseHit != null && colliderMouseHit == debuffCollider)
			isBeingDragged = true;
	}

	private void OnMouseUp()
	{
		isBeingDragged = false;
	}
	
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		int randomIndex = Random.Range(0, functionsList.Count);
		if (otherCollider.gameObject.CompareTag("Witch"))
		{
			functionsList[randomIndex]();
			Destroy(gameObject);
		}

		if (otherCollider.gameObject.CompareTag("KillSpot"))
		{
			Destroy(gameObject);
		}
	}


	private void RemoveAmount()
	{
		int randomIndex = Random.Range(0, giveAmountsList.Count);
		giveAmountsList[randomIndex]();
	}

	private void RemoveAmountRed()
	{
		GameManager.gameManagerInstance.redCollected -= 5;
	}

	private void RemoveAmountBlue()
	{
		GameManager.gameManagerInstance.blueCollected -= 5;
	}

	private void RemoveAmountGreen()
	{
		GameManager.gameManagerInstance.greenCollected -= 5;
	}

	private void RemoveTime()
	{
		GameManager.gameManagerInstance.roundLength -= 5;
	}

	private void SlowDownMouse()
	{
		Debug.Log("hello");
		GameManager.gameManagerInstance.mouseSpeed = debuffMouseSpeed;

		GameManager.gameManagerInstance.StartCoroutine(
			GameManager.gameManagerInstance.SpeedUpMouse(slowTime));
	}
}
