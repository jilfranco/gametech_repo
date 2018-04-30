using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// cauldron scors
	[SerializeField] public int redCollected;
	[SerializeField] public int blueCollected;
	[SerializeField] public int greenCollected;

	// list of active magic on screen
	[SerializeField] public List<GameObject> activeMagicList;

	// list of magic prefabs to spawn from
	[SerializeField] private List<GameObject> magicPrefabsList;
	
	[SerializeField] private int maxMagicAmount;

	// tracking game time
	[SerializeField] public float roundLength;
	public float currentTime;
	public float timeRemaining;

	void Start()
	{
		gameManagerInstance = this;
	}

	void Update()
	{
		// respawn magic as active magic pieces are destroyed
		while (activeMagicList.Count < maxMagicAmount)
		{
			InstanstiateRandomMagic();
			Debug.Log("there's less than the max magic");
		}
		
		// keeping track of round time
		currentTime = Time.timeSinceLevelLoad;
		timeRemaining = roundLength - currentTime;
	}

	private void InstanstiateRandomMagic()
	{
		// spawn a random magic piece from the list of prefabs
		Vector2 instantiationPos = new Vector2(Random.Range(11.0f, 15.0f), Random.Range(0.0f, 4.0f));
		int randomIndex = Random.Range(0, magicPrefabsList.Count);
		GameObject instantiatedMagic = Instantiate(magicPrefabsList[randomIndex], instantiationPos, Quaternion.identity);
		activeMagicList.Add(instantiatedMagic);
	}
}
