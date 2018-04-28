using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicType
{
	Red,
	Blue,
	Green
}

public class GameManager : MonoBehaviour
{
	public static GameManager gameManagerInstance;

	public int redCollected;
	public int blueCollected;
	public int greenCollected;
	public List<GameObject> activeMagicList;


	[SerializeField] private List<GameObject> magicPrefabsList;
	[SerializeField] private int maxMagicAmount;

	void Start()
	{
		gameManagerInstance = this;
	}
	
	void Update()
	{
		while (activeMagicList.Count < maxMagicAmount)
			InstanstiateRandomMagic();
		}

	private void InstanstiateRandomMagic()
	{
		Vector2 instantiationPos = new Vector2(Random.Range(11.0f,15.0f), Random.Range(0.0f,4.0f));
		int randomIndex = Random.Range(0, magicPrefabsList.Count);
		GameObject instantiatedMagic = Instantiate(magicPrefabsList[randomIndex], instantiationPos, Quaternion.identity);
		activeMagicList.Add(instantiatedMagic);
	}
}
