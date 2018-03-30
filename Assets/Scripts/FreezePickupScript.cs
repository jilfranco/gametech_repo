using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePickupScript : MonoBehaviour
{
    [SerializeField] float freezeTime;
    private Collider2D pickupCollider;
    private Rigidbody2D pickupRigidbody;

    private void Awake()
    {
        pickupCollider = GetComponent<CircleCollider2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }

	private void Update()
	{
		transform.Rotate (Vector3.forward * -1);
	}

	private IEnumerator FreezePlatforms()
	{
		yield return new WaitForSeconds(freezeTime);
	}
}
