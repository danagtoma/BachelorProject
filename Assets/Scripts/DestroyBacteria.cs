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
    [SerializeField] Image pasteBar;
    [SerializeField] float pasteAmount = 100f;
    private Boolean hasPaste = true;

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
            LowerPaste(10);
        }

        if (other.CompareTag(pasteTag))
        {
            Destroy(other.gameObject);
            FillPaste(40);
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
