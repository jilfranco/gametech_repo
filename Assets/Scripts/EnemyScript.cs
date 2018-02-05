using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	private float respawnX;
	private float respawnY;
	private GameObject Player;

	private void Awake()
	{
		Player = GameObject.Find("Player");
	}

	private void Start()
	{
		respawnX = transform.position.x;
	}

	private void OnCollisionEnter2D(Collision2D collisionEvent)
	{
		if (collisionEvent.gameObject.CompareTag("Laser"))
		{
			KillEnemy();
			Debug.Log("hello, i am your if statement");
		}

		else if (collisionEvent.gameObject.CompareTag("Player"))
			Destroy(Player);
	}

	public void RespawnEnemy()
	{
		gameObject.SetActive(true);
		Vector2 newPosition = new Vector2(respawnX, respawnY);
		transform.position = newPosition;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	private void KillEnemy()
	{
		GameManager.managerInstance.ManagerKillEnemy(gameObject);
	}
}
