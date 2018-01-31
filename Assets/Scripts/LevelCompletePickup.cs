using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePickup : MonoBehaviour
{
	[SerializeField] private UIManager managerReference;

    private void OnTriggerEnter2D(Collider2D playerCollision)
    {
		managerReference.TurnOnLevelCompleteUI();
    }    
}
