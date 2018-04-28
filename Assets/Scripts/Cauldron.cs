using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
	[SerializeField] private MagicType cauldronColor;
	[SerializeField] private GameObject explosion;

	public MagicType cauldronMagicType { get { return cauldronColor; } }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Magic"))
		{
			explosion.SetActive(true);
			StartCoroutine(KillExplosion());

		}
	}

	private IEnumerator KillExplosion()
	{
		yield return new WaitForSeconds(explosion.GetComponent<ParticleSystem>().main.duration);
		explosion.SetActive(false);
	}
}
