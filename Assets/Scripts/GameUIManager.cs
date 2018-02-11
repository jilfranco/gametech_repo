using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Image distanceBar;
    [SerializeField] private Image healthBar;
    //private float hbFillAmount;
    //private float dbFillAmount;

    void Awake()
    {
        healthBar.fillAmount = 1;
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
            healthBar.fillAmount = currentHealth / maxHealth;
        else if (currentHealth == maxHealth - 2)
            healthBar.fillAmount = healthBar.fillAmount = currentHealth / maxHealth;
        else if (currentHealth == 0)
            healthBar.fillAmount = healthBar.fillAmount = 0;
    }
}
