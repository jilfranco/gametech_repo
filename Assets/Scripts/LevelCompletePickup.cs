using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletePickup : MonoBehaviour
{
    [SerializeField] private float uiStaySeconds;
    [SerializeField] private GameObject fadeImageUI;
    [SerializeField] private GameObject levelFailedText;
    [SerializeField] private GameObject levelCompleteText;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player.transform.localScale.x > 2.251f)
        {
            StartCoroutine(EndLevel());
        }
    }
    private void OnTriggerEnter2D(Collider2D playerCollision)
    {
        Debug.Log("Level Complete Triggered");
	    StartCoroutine(LevelComplete());
    }

    private IEnumerator EndLevel()
    {
        Debug.Log("End Level");
        fadeImageUI.SetActive(true);
        levelFailedText.SetActive(true);
		Destroy(GetComponent<Collider2D>());
        yield return new WaitForSeconds(uiStaySeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LevelComplete()
    {
        Debug.Log("Level Complete");
        fadeImageUI.SetActive(true);
        levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(uiStaySeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
