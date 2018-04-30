using System.Collections;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
	[SerializeField] private MagicType cauldronColor;
	[SerializeField] private GameObject explosion;

	// returns what color the cauldron is
	public MagicType cauldronMagicType { get { return cauldronColor; } }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// play explosion particles when hit!
		if (collision.gameObject.CompareTag("Magic"))
		{
			explosion.SetActive(true);
			StartCoroutine(DeactivateExplosion());
		}
	}

	private IEnumerator DeactivateExplosion()
	{
		// gotta turn this particle boy off
		yield return new WaitForSeconds(explosion.GetComponent<ParticleSystem>().main.duration);
		explosion.SetActive(false);
	}
}
