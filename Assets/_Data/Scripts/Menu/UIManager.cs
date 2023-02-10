using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public float editTimeScale = 0f;
    private void Start()
    {
        //Time.timeScale = editTimeScale;
    }
    public void Tutorial()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
    }
    public void exitTutorial()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
