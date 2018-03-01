using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathCollisionScript : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
			GameManager.gameManagerInstance.KillPlayer();
	}
}
