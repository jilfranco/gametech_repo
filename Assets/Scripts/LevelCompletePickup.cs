using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletePickup : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    private void OnTriggerEnter2D(Collider2D levelCompleteCollison)
    {
        Debug.Log("Level Complete");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
