using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyBacteria : MonoBehaviour
{
    [SerializeField] private string enemyTag = "bacteria";
    [SerializeField] private string pasteTag = "toothpaste";
    [SerializeField] private string flossTag = "floss";
    [SerializeField] Image pasteBar;
    [SerializeField] float pasteAmount = 100f;
    private Boolean hasPaste = true;
    [SerializeField] ShieldManager shieldManager;
    [SerializeField] private BacteriaSpawner spawner;

    void Update()
    {
        if (pasteAmount <= 0)
        {
            hasPaste = false;
        }
        else
        {
            hasPaste = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag) && hasPaste == true)
        {
            Destroy(other.gameObject);
            spawner.DeleteObject(other.gameObject);
            LowerPaste(10);
        }

        if (other.CompareTag(pasteTag))
        {
            Destroy(other.gameObject);
            spawner.DeleteObject(other.gameObject);
            FillPaste(40);
        }

        if (other.CompareTag(flossTag))
        {
            Destroy(other.gameObject);
            spawner.DeleteObject(other.gameObject);

            if (shieldManager != null)
            {
                shieldManager.ShowShield();
            }
            else
            {
                Debug.LogError("ShieldManager is not assigned!");
            }
        }
    }
    public void LowerPaste(float damage)
    {
        pasteAmount -= damage;
        pasteBar.fillAmount = pasteAmount / 100f;
    }

    public void FillPaste(float healingAmount)
    {
        pasteAmount += healingAmount;
        pasteAmount = Math.Clamp(pasteAmount, 0, 100);

        pasteBar.fillAmount = pasteAmount / 100f;
    }

}
