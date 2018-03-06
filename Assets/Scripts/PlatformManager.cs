using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
	public static PlatformManager platformManagerInstance {get; private set;}

	[SerializeField] private List<GameObject> platformPrefabs;
	[SerializeField] private float maxPlatformsNum;

	private Vector2 originPosition;

	private void Awake()
	{
		platformManagerInstance = this;
	}

	private void Start()
	{
		originPosition = transform.position;
		InitializePlatforms();
	}

	private void InitializePlatforms()
	{
		for(int i = 0; i < maxPlatformsNum; i++)
		{
			int randomPlatform = UnityEngine.Random.Range(0, platformPrefabs.Count);
			Vector2 worldMin = Camera.main.ViewportToWorldPoint(new Vector2(0.1f, 0.08f));
			Vector2 worldMax = Camera.main.ViewportToWorldPoint(new Vector2(0.9f, 0.88f));
			Vector2 randomPosition = new Vector2(UnityEngine.Random.Range(worldMin.x, worldMax.x), UnityEngine.Random.Range(worldMin.y, worldMax.y));
			Instantiate(platformPrefabs[randomPlatform], randomPosition, Quaternion.identity);
		}
	}

	public static void KillAPlatform(GameObject deadPlatform)
	{
		platformManagerInstance.StartCoroutine(KillPlatform(deadPlatform));
	}

	public static IEnumerator KillPlatform(GameObject deadPlatform)
	{
		yield return new WaitForSeconds(5);
		Destroy(deadPlatform);
	}
}
