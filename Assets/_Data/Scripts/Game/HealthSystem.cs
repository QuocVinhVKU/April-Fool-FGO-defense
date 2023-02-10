using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class HealthSystem : MonoBehaviour
{
    //The UI text for health count
    public TextMeshProUGUI txtHealthCount;
    //default value of health count (used for init)
    public int defaultHealthCOunt;
    //current health count
    public int healthCount;
    public GameObject lostPanel;

    //init the healthSystem(reset the heal count)
    public void Init()
    {
        healthCount = defaultHealthCOunt;
        txtHealthCount.text = healthCount.ToString();
    }

    //lose health count
    public void LoseHealth()
    {
        if (healthCount < 1)
        {
            return;
        }
        healthCount--;
        txtHealthCount.text = healthCount.ToString();
        checkHealthCount();
    }
    void checkHealthCount()
    {
        if(healthCount < 1)
        {
            lostPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
