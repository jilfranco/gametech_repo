using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void Start()
    {
        RespawnEnemy();
    }

	private void OnCollisionEnter2D(Collision2D collisionEvent)
	{
	    if (collisionEvent.gameObject.CompareTag("Laser"))
	    {
			GameManager.managerInstance.ManagerKillLaser(collisionEvent.gameObject);
			GameManager.managerInstance.ManagerKillEnemy(gameObject);
	    }

		else if (collisionEvent.gameObject.CompareTag("Player"))
            GameManager.managerInstance.ManagerKillPlayer();
	}

	public void RespawnEnemy()
	{
		gameObject.SetActive(true);

		Vector2 enemySpawnBoundsMin = Camera.main.ViewportToWorldPoint(Vector2.zero);
		Vector2 enemySpawnBoundsMax = Camera.main.ViewportToWorldPoint(Vector2.one);
		
		float randomXMover = Random.Range(enemySpawnBoundsMin.x + 2, enemySpawnBoundsMax.x - 2);

		float newXPosition = Mathf.Clamp(transform.position.x, randomXMover, randomXMover);
		float newYPosition = Mathf.Clamp(transform.position.y, enemySpawnBoundsMax.y + 3, enemySpawnBoundsMax.y + 3);

		transform.position = new Vector2(newXPosition, newYPosition);

		//GetComponent<Rigidbody2D>().AddForce(transform.up * -100); 
	}
}
