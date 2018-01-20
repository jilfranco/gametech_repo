using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private float moveX;
    private float moveY;
	
	// Update is called once per frame
	private void Update ()
    {
        CheckKeyInput();
        MovePlayer();
	}

    private void CheckKeyInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        //transform.Translate(new Vector3(moveX * moveSpeed, moveY * moveSpeed, 0));
        Vector2 newPosition = transform.position;
        newPosition = newPosition + new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
}
