using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	//private float respawnX;
	//private float respawnY;
	private GameObject Player;

	private void Awake()
	{
		Player = GameObject.Find("Player");
	}

	private void Start()
	{
		//respawnX = transform.position.x;
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

		Vector2 enemySpawnBoundsMin = Camera.main.ViewportToWorldPoint(Vector2.zero);
		Vector2 enemySpawnBoundsMax = Camera.main.ViewportToWorldPoint(Vector2.one);
		
		float randomXMover = Random.Range(enemySpawnBoundsMin.x, enemySpawnBoundsMax.x);

		float newXPosition = Mathf.Clamp(transform.position.x, randomXMover, randomXMover);
		float newYPosition = Mathf.Clamp(transform.position.y, enemySpawnBoundsMax.y + 3, enemySpawnBoundsMax.y + 3);

		transform.position = new Vector2(newXPosition, newYPosition);

		GetComponent<Rigidbody2D>().AddForce(transform.up * -100); 
	}

	private void KillEnemy()
	{
		GameManager.managerInstance.ManagerKillEnemy(gameObject);
	}
}
