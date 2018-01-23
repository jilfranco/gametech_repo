using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private GameObject lilFace;
    [SerializeField] private GameObject powerUpVfx;
    private void OnTriggerEnter2D(Collider2D playerCollision)
    {
        Debug.Log("Power Up. Well done!");
        playerCollision.transform.localScale *= 0.5f;
        lilFace.SetActive(true);
        powerUpVfx.SetActive(true);
        Destroy(gameObject);
    }
}
