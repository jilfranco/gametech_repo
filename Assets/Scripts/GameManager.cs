using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// make the global instance of the Game Manager, make it public to get, private to set 
	// (as to not accidentally set it somewhere else like a doofus)
	public static GameManager managerInstance { get; private set; }

	public GameObject[] enemyArray;
	public List<GameObject> activeEnemyList;

    private GameObject player;

	private void Awake()
	{
		managerInstance = this;
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
        Destroy(player);
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
        Debug.Log("hello");
	    activeEnemyList.Remove(deadEnemy);
		deadEnemy.SetActive(false);
		if (activeEnemyList.Count == 0)
			StartCoroutine(ManagerResetAllEnemies());
	}

	private IEnumerator ManagerResetAllEnemies()
	{
		yield return new WaitForSeconds(2);
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
}
