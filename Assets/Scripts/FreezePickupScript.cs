using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePickupScript : MonoBehaviour
{
    [SerializeField] float scaleSpeed;
    private Collider2D pickupCollider;
    private Rigidbody2D pickupRigidbody;
    private bool scalePickup;

    private void Awake()
    {
        pickupCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (scalePickup)
        {
            StartCoroutine(ScalePickup());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            scalePickup = true;
        }
    }

    private IEnumerator ScalePickup()
    {
        Vector3 ogSize = transform.localScale;
        Vector3 growSize = new Vector3(1.5f, 1.5f, 1);
        Vector3 shrinkSize = new Vector3(0, 0, 0);
        transform.localScale = Vector3.Lerp(ogSize, growSize, Time.deltaTime * scaleSpeed);
        yield return new WaitForSeconds(3);
        transform.localScale = Vector3.Lerp(growSize, shrinkSize, Time.deltaTime * (scaleSpeed*5));
        scalePickup = false;
    }
}
