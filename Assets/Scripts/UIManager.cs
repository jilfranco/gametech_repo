using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WaitForNextFrame = UnityEngine.WaitForEndOfFrame;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeImage;
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject levelCompleteText;
    [SerializeField] private GameObject gameCompleteText;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    private IEnumerator FadeLevelStartUI()
    {
        yield return new WaitForEndOfFrame();
    }
}
