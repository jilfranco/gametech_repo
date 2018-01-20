using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private GameObject PowerUpGameObject;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    private void OnTriggerEnter2D(Collider2D powerUpCollision)
    {
        Debug.Log("power up");
    }
}
