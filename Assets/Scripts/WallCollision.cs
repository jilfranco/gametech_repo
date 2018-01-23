using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        playerCollision.transform.localScale *= 1.5f;
        Debug.Log("Player collison");
    }
}
