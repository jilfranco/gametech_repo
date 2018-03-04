using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    [SerializeField] private float jumpforce;

    public Rigidbody2D playerRB;
    public bool grounded;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        grounded = false;
        playerRB.AddForce(Vector2.up * jumpforce);
    }


    //set if player can jump
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
    }
}
