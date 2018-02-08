using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// make the global instance of the Game Manager, make it public to get, private to set 
	// (as to not accidentally set it somewhere else like a doofus)
	public static GameManager gameManagerInstance { get; private set; }

	// game manager variables
	public GameObject[] enemyArray;
	public List<GameObject> activeEnemyList;

    private GameObject player;

	// gameplay variables
	[Header("Gameplay Variables")]
	[SerializeField] private float enemyRespawnTime;

	private void Awake()
	{
		gameManagerInstance = this;
        player = GameObject.Find("Player");
	}
	
	private void Start()
	{
		enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
		ManagerInitializeEnemies();
	}

    // player functions
    public void ManagerKillPlayer()
    {
		player.GetComponent<PolygonCollider2D>().enabled = false;
		GameObject playerSpaceShip = player.transform.GetChild(1).gameObject; // gets the 2nd child of the player gameObject
		ParticleSystem playerExplosion = player.transform.GetChild(2).GetComponent<ParticleSystem>(); // gets the 3rd child of the player gameObject
		
		playerSpaceShip.SetActive(false);
		playerExplosion.Play();
		StartCoroutine(SlowTime(1.25f));
    }

    // enemies functions
	private void ManagerInitializeEnemies()
	{
		activeEnemyList = new List<GameObject>();
		foreach (GameObject enemy in enemyArray)
			activeEnemyList.Add(enemy);
	}

	public void ManagerKillEnemy(GameObject deadEnemy)
	{
	    activeEnemyList.Remove(deadEnemy);
		deadEnemy.SetActive(false);
		if (activeEnemyList.Count == 0)
			StartCoroutine(ManagerResetAllEnemies());
	}

	private IEnumerator ManagerResetAllEnemies()
	{
		yield return new WaitForSeconds(enemyRespawnTime);
		foreach (GameObject enemy in enemyArray)
		{
			enemy.GetComponent<EnemyScript>().RespawnEnemy();
			activeEnemyList.Add(enemy);
			enemy.SetActive(true);
		}
	}

    // laser functions

    public void ManagerKillLaser(GameObject deadLaser)
    {
        if (deadLaser.CompareTag("Laser"))
            Destroy(deadLaser);
        else
            Debug.LogWarning("You're trying to LASER KILL something that isn't a laser, dummy.", deadLaser);
    }

	// time slow down funtion

	private IEnumerator SlowTime(float lengthOfSlowdown)
	{
		float currentTime = 0.0f;
		while (currentTime < lengthOfSlowdown)
		{
			float percent = Mathf.Sqrt(currentTime / lengthOfSlowdown);
			Time.timeScale = Mathf.Lerp(1.0f, 0.0f, percent);
			currentTime += Time.unscaledDeltaTime;
			yield return new WaitForEndOfFrame();
		}

		Time.timeScale = 0.0f;
	}
}
