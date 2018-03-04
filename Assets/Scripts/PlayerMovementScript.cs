using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    private float xMove;
    private Rigidbody2D playerRB;
    private SpriteRenderer playerSprite;
    private bool facingRight;

    private void Start()
    {
        facingRight = true;
        playerRB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckInput()
    {
        xMove = Input.GetAxis("Horizontal") * xSpeed;
    }

    private void MovePlayer()
    {
        playerRB.velocity = new Vector2(xMove, playerRB.velocity.y);

        // flip player sprite
        if (playerRB.velocity.x < -0.1f && facingRight)
        {
            facingRight = false;
            playerSprite.flipX = true;
        }
        else if (playerRB.velocity.x > 0.1f && !facingRight)
        {
            facingRight = true;
            playerSprite.flipX = false;
        }
    }

}
