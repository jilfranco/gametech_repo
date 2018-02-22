using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManagerInstance { get; private set; }
	
	public GameObject[] platformArray;
	public List<GameObject> activePlatformsList;

	[Header("Gameplay Variables")]
	[SerializeField] public float platformMoveSpeed;

	private void Awake()
	{
		gameManagerInstance = this;
	}

	private void Start()
	{
		platformArray = Resources.LoadAll("Prefabs/Platforms").Cast<GameObject>().ToArray();
	}

	private void Update()
	{

	}

	private void InitializePlatforms()
	{
		activePlatformsList = new List<GameObject>();
		foreach (GameObject platform in platformArray)
			activePlatformsList.Add(platform);
	}

	private void DestroyPlatform()
	{
		
	}

	private void CreatePlatform()
	{
		
	}
}
