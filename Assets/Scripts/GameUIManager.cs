using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Image healthBarUI;
    [SerializeField] private GameObject levelEndUI;
    [SerializeField] private GameObject enemiesKilledNumberUI;
    [SerializeField] private GameObject enemiesMissedNumberUI;
    [SerializeField] private GameObject distanceNumberUI;
	[SerializeField] private Button restartButton;
	[SerializeField] private Button menuButton;

	private bool didEndScreenAlready;
	private float distance;

    void Awake()
    {
        healthBarUI.fillAmount = 1;
    }

	private void Start()
	{
		restartButton.onClick.AddListener(ResartButtonClicked);
		menuButton.onClick.AddListener(MenuButtonClicked);
	}

	void Update()
    {
        distance = Time.timeSinceLevelLoad;
		CheckHealth();
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
		restartButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);
        levelEndUI.SetActive(true);
		restartButton.Select();
	}

	public void ResartButtonClicked()
	{
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1;
	}

	public void MenuButtonClicked()
	{
		SceneManager.LoadScene("MenuScene");
		Time.timeScale = 1;
	}
}
