using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WaitForNextFrame = UnityEngine.WaitForEndOfFrame;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeImageUI;
    [SerializeField] private GameObject levelCompleteText;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(LevelStartUI());
	}
	
    private IEnumerator LevelStartUI()
    {
        Debug.Log("Level Complete");
        fadeImageUI.SetActive(true);
        levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(3);
    }
}
