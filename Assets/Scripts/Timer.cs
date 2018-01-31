using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private UIManager timerWaitReference;
	private float timeElapsed;
    
	void Start ()
	{
	    timerWaitReference.TurnOnTimer();
	}
	
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
