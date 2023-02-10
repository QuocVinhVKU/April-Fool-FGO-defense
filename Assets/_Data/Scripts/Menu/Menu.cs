using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject windowPanel;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ShowCreditPanel()
    {
        creditPanel.SetActive(true);
        windowPanel.SetActive(false);
    }
    public void HideCreditPanel()
    {
        creditPanel.SetActive(false);
        windowPanel.SetActive(true);
    }
}
