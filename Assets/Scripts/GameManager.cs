using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManagerInstance { get; private set; }

	[SerializeField] private GameObject player;

	private void Awake()
	{
		gameManagerInstance = this;
	}

	public void KillPlayer()
	{
		SceneManager.LoadScene("startMenu");
	}
}
