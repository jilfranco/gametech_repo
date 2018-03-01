using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
		Collider2D playerCollider = player.GetComponent<Collider2D>();
		playerCollider.enabled = false;
	}
}
