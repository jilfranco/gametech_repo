using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpScript : MonoBehaviour
{
    private JumpingScript jumpingScriptComponent;

    private bool canDoubleJump;
    private bool shouldDoubleJump;

    private void Start()
    {
        jumpingScriptComponent = GetComponent<JumpingScript>();
    }

    private void Update()
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
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !jumpingScriptComponent.onGround)
        {
            shouldDoubleJump = true;
        }
    }

    void CheckGround()
    {
        if (jumpingScriptComponent.onGround)
        {
            canDoubleJump = true;
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
        shouldDoubleJump = false;
        canDoubleJump = false;
        Vector2 newVelocity = new Vector2(jumpingScriptComponent.playerRigidBody.velocity.x, 0);
        jumpingScriptComponent.playerRigidBody.velocity = newVelocity;
        jumpingScriptComponent.playerRigidBody.AddForce(Vector2.up * jumpingScriptComponent.jumpForce);
    }
}
