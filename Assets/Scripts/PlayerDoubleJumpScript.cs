using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpScript : MonoBehaviour
{
    [SerializeField] private float doubleJumpForce;
    [SerializeField] private GameObject doubleJumpTrail;

    private PlayerJumpScript playerJumpScript;

    private bool canDoubleJump;
    private bool shouldDoubleJump;

    void Start()
    {
        playerJumpScript = GetComponent<PlayerJumpScript>();
        shouldDoubleJump = false;
    }

    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        CheckGround();
        CheckDoubleJump();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !playerJumpScript.grounded)
        {
            shouldDoubleJump = true;
        }
    }

    private void CheckGround()
    {
        if (playerJumpScript.grounded)
        {
            canDoubleJump = true;
			doubleJumpTrail.SetActive(false);
        }
    }

    private void CheckDoubleJump()
    {
        if (shouldDoubleJump)
        {
            DoubleJump();
        }
    }

    private void DoubleJump()
    {
        canDoubleJump = false;
        shouldDoubleJump = false;
        playerJumpScript.playerRB.AddForce(Vector2.up * doubleJumpForce);
		doubleJumpTrail.SetActive(true);
    }
}
