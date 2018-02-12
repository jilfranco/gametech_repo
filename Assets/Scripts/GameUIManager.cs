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

    void Awake()
    {
        healthBarUI.fillAmount = 1;
    }

    void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        int maxHealth = GameManager.gameManagerInstance.managerMaxHealth;
        int currentHealth = GameManager.gameManagerInstance.managerCurrentHealth;
        

        if (currentHealth == maxHealth - 1)
            healthBarUI.fillAmount = currentHealth / maxHealth;
        else if (currentHealth == maxHealth - 2)
            healthBarUI.fillAmount = healthBarUI.fillAmount = currentHealth / maxHealth;
        else if (currentHealth == 0)
        {
            healthBarUI.fillAmount = healthBarUI.fillAmount = 0;
            StartCoroutine(EndUIText());

        }
    }

    private IEnumerator EndUIText()
    {
        Debug.Log("hello i am your end level ui nums");
        enemiesKilledNumberUI.GetComponent<Text>().text = GameManager.gameManagerInstance.enemiesKilled.ToString("##");
        enemiesMissedNumberUI.GetComponent<Text>().text = GameManager.gameManagerInstance.enemiesMissed.ToString("##");
        yield return new WaitForSecondsRealtime(1.5f);
        levelEndUI.SetActive(true);
    }
}
