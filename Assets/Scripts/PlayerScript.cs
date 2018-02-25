using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float maxVelocity;
    private Rigidbody2D playerRB;
    private Vector2 currentVelocity;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        playerRB.AddForce(Vector2.right * speedMultiplier);
        currentVelocity = playerRB.velocity;

        if (currentVelocity.x < maxVelocity)
        {
            currentVelocity = new Vector2(maxVelocity, 0);
            playerRB.velocity = currentVelocity;
        }
    }
}
