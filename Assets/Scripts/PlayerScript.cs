using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float maxVelocity;
    private Rigidbody2D playerRB;

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

        if (playerRB.velocity.x > maxVelocity)
        {
            playerRB.velocity = new Vector2(maxVelocity, playerRB.velocity.y);
        }
    }

}
