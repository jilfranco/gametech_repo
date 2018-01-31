using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletePickup : MonoBehaviour
{
	[SerializeField] private UIManager managerReference;

    private void OnTriggerEnter2D(Collider2D playerCollision)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MazeLevel_2"))
            managerReference.TurnOnGameEndUI();
        else
            managerReference.TurnOnLevelCompleteUI();
    }    
}
