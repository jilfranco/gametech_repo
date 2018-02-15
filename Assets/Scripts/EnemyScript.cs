using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // move speed variables
    [SerializeField] private float enemyMoveSpeedMin;
    [SerializeField] private float enemyMoveSpeedMax;
    [SerializeField] private ParticleSystem enemyExplosionPrefab;
	
	private void Start()
    {
        RespawnEnemy();
    }

	private void Update()
	{
		float enemyMoveSpeed = Random.Range(enemyMoveSpeedMin, enemyMoveSpeedMax);
		Vector2 position = (Vector2)transform.position + Vector2.down * enemyMoveSpeed * Time.deltaTime;
		GetComponent<Rigidbody2D>().MovePosition(position);
	}

	private void OnCollisionEnter2D(Collision2D collisionEvent)
	{
	    if (collisionEvent.gameObject.CompareTag("Laser"))
	    {
			GameManager.gameManagerInstance.ManagerKillLaser(collisionEvent.gameObject);
			GameManager.gameManagerInstance.ManagerKillEnemy(gameObject);
            GameManager.gameManagerInstance.ManagerEnemiesKilledCounter();
		    ParticleSystem deathParticles = Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
		    GameManager.gameManagerInstance.StartCoroutine(GameManager.gameManagerInstance.DestroyParticleSystem(deathParticles));
	    }

		else if (collisionEvent.gameObject.CompareTag("Player"))
	    {
            GameManager.gameManagerInstance.ManagerMinusPlayerHealth();
		    GameManager.gameManagerInstance.ManagerKillEnemy(gameObject);
		    ParticleSystem deathParticles = Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
		    GameManager.gameManagerInstance.StartCoroutine(GameManager.gameManagerInstance.DestroyParticleSystem(deathParticles));
	    }

		else if (collisionEvent.gameObject.CompareTag("EnemyKillCollision"))
	    {
			GameManager.gameManagerInstance.ManagerKillEnemy(gameObject);
	        GameManager.gameManagerInstance.ManagerEnemiesMissedCounter();
	    }
	}

	public void RespawnEnemy()
	{
		gameObject.SetActive(true);
		gameObject.transform.GetChild(0).gameObject.SetActive(true);

		Vector2 enemySpawnBoundsMin = Camera.main.ViewportToWorldPoint(Vector2.zero);
		Vector2 enemySpawnBoundsMax = Camera.main.ViewportToWorldPoint(Vector2.one);
		
		float randomXMover = Random.Range(enemySpawnBoundsMin.x + 2, enemySpawnBoundsMax.x - 2);
		float randomYMover = Random.Range(enemySpawnBoundsMin.y + 2, enemySpawnBoundsMax.y + 7);

		float newXPosition = Mathf.Clamp(transform.position.x, randomXMover, randomXMover);
		float newYPosition = Mathf.Clamp(transform.position.y, enemySpawnBoundsMax.y + randomYMover, enemySpawnBoundsMax.y + randomYMover);

		transform.position = new Vector2(newXPosition, newYPosition);
	}
}
