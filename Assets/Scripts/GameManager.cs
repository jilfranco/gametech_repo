using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject[] enemyArray;
	public List<GameObject> activeEnemyList;

	// make the global instance of the Game Manager, make it public to get, private to set 
	// (as to not accidentally set it somewhere else like a doofus)
	public static GameManager managerInstance { get; private set; }

	private void Awake()
	{
		managerInstance = this;
	}
	
	private void Start()
	{
		enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
		ManagerInitializeEnemies();
	}

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
		yield return new WaitForSeconds(2);
		foreach (GameObject enemy in enemyArray)
		{
			enemy.GetComponent<EnemyScript>().RespawnEnemy();
			activeEnemyList.Add(enemy);
			enemy.SetActive(true);
		}
	}
}
