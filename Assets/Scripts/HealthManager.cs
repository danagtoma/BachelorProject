using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] float healthAmount = 100f;
    [SerializeField] int homeScene;

    void Update()
    {
        if(healthAmount <= 0)
        {
           SceneManager.LoadScene(homeScene);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(20);
        }

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Math.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
