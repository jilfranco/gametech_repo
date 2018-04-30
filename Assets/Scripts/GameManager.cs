using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// this is kinda like tags but different. multiple things
// can use this to do comparisons
public enum MagicType
{
	Red,
	Blue,
	Green
}

public class GameManager : MonoBehaviour
{
	public static GameManager gameManagerInstance;

	// cauldron scores
	[Header("Cauldron Amounts")]
	[SerializeField] public int redCollected;
	[SerializeField] public int blueCollected;
	[SerializeField] public int greenCollected;

	[Header("Magic")]
	[SerializeField] private int maxMagicAmount;
	
	// list of active magic on screen
	[SerializeField] public List<GameObject> activeMagicList;

	// list of magic prefabs to spawn from
	[SerializeField] private List<GameObject> magicPrefabsList;
	
	[Header("Gameplay")]
	// tracking game time
	[SerializeField] public float roundLength;
	[SerializeField] public float currentTime, timeRemaining, totalScore;
	[SerializeField] public bool gameOver;
	[SerializeField] public bool buffActive;
	[SerializeField] public bool debuffActive;
	[HideInInspector] public float mouseSpeed;

	[Header("Buff & Debuff")] 
	[SerializeField] private GameObject buffPrefab;
	[SerializeField] private GameObject debuffPrefab;

	void Start()
	{
		gameManagerInstance = this;
		mouseSpeed = 1.0f; // don't start slowed
		debuffActive = true;
		StartCoroutine(DebuffStartDelay());
	}

	void Update()
	{
		// respawn magic as active magic pieces are destroyed
		while (activeMagicList.Count < maxMagicAmount)
		{
			InstanstiateRandomMagic();
		}
		
		// keeping track of round time
		currentTime = Time.timeSinceLevelLoad;
		timeRemaining = roundLength - currentTime;
		if (timeRemaining < 0.01f)
		{
			gameOver = true;
			EndGame();
		}

		// making sure amount is never below 0
		if (redCollected < 0)
			redCollected = 0;

		if (blueCollected < 0)
			blueCollected = 0;

		if (greenCollected < 0)
			greenCollected = 0;

		// spawning buffs n debuffs


		if (!buffActive)
		{
			StartCoroutine(InstantiateBuff());
		}

		if (!debuffActive)
		{
			StartCoroutine(InstantiateDebuff());
		}
	}

	private IEnumerator DebuffStartDelay()
	{
		yield return new WaitForSeconds(2);
		debuffActive = false;
	}

	private void InstanstiateRandomMagic()
	{
		// spawn a random magic piece from the list of prefabs
		Vector2 instantiationPos = new Vector2(Random.Range(11.0f, 15.0f), Random.Range(0.0f, 4.0f));
		int randomIndex = Random.Range(0, magicPrefabsList.Count);
		GameObject instantiatedMagic = Instantiate(magicPrefabsList[randomIndex], instantiationPos, Quaternion.identity);
		activeMagicList.Add(instantiatedMagic);
	}

	private IEnumerator InstantiateBuff()
	{
		buffActive = true;
		Vector2 instantiationPos = new Vector2(Random.Range(-6.6f, -4.3f), 5.8f);
		Instantiate(buffPrefab, instantiationPos, Quaternion.identity);
		yield return new WaitForSeconds(Random.Range(10.0f,15.0f));
		buffActive = false;
	}

	private IEnumerator InstantiateDebuff()
	{
		debuffActive = true;
		Vector2 instantiationPos = new Vector2(Random.Range(-6.6f, -4.3f), 5.8f);
		Instantiate(debuffPrefab, instantiationPos, Quaternion.identity);
		yield return new WaitForSeconds(Random.Range(9.0f,12.0f));
		debuffActive = false;
	}

	public IEnumerator SpeedUpMouse(float slowTime)
	{
		yield return new WaitForSeconds(slowTime);
		mouseSpeed = 1.0f;
	}

	private void EndGame()
	{
		totalScore = redCollected + blueCollected + greenCollected;

	}


}
