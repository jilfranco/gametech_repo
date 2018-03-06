using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallScript : MonoBehaviour
{
	[SerializeField] private float platformFallDelay;

	private Rigidbody2D platformRB;

	void Awake()
	{
		platformRB = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			StartCoroutine(PlatformFall());
		}
	}

	private IEnumerator PlatformFall()
	{
		yield return new WaitForSeconds(1);
		platformRB.isKinematic = false;
		gameObject.layer = LayerMask.NameToLayer("PlatformInactive");
		PlatformManager.KillAPlatform(gameObject);

	}
}
