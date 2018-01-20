using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D wallCollision)
    {
        Debug.Log("Enter, better kill em");
    }

}
