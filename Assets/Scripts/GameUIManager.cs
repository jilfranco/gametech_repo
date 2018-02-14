using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Image distanceBarUI;
    [SerializeField] private Image healthBarUI;
    [SerializeField] private GameObject levelEndUI;
    [SerializeField] private GameObject enemiesKilledNumberUI;
    [SerializeField] private GameObject enemiesMissedNumberUI;
    [SerializeField] private GameObject distanceNumberUI;

	private bool didEndScreenAlready;
	private float distance;

    void Awake()
    {
        healthBarUI.fillAmount = 1;
    }

    void Update()
    {
        distance = Time.timeSinceLevelLoad;
		CheckHealth();
		FillDistanceBar();
    }

	private void FillDistanceBar()
	{
		distanceBarUI.fillAmount = distance/100;
	}

	private void CheckHealth()
    {
        int maxHealth = GameManager.gameManagerInstance.managerMaxHealth;
        int currentHealth = GameManager.gameManagerInstance.managerCurrentHealth;
		
		healthBarUI.fillAmount = (float)currentHealth/maxHealth;

		if (!didEndScreenAlready && currentHealth <= 0)
		{
			didEndScreenAlready = true;
			StartCoroutine(EndUIText());
		}
    }

    private IEnumerator EndUIText()
    {
        enemiesKilledNumberUI.GetComponent<Text>().text = GameManager.gameManagerInstance.enemiesKilled.ToString("##");
        enemiesMissedNumberUI.GetComponent<Text>().text = GameManager.gameManagerInstance.enemiesMissed.ToString("##");
		distanceNumberUI.GetComponent<Text>().text = distance.ToString("##");
        yield return new WaitForSecondsRealtime(1.5f);
        levelEndUI.SetActive(true);
    }
}
