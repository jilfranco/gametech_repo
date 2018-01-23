using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeElapsed;
    //private GameObject timerText;

	// Use this for initialization
	void Start ()
	{
	    //timerText = GameObject.Find("TimerText");
	}
	
	// Update is called once per frame
	void Update ()
    {
		GetAndSetTime();
	}

    private void GetAndSetTime()
    {
        timeElapsed = Time.timeSinceLevelLoad;
        this.GetComponent<Text>().text = "Time Elapsed: " + timeElapsed.ToString("#0.0");
    }
}
