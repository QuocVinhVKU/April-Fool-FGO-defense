using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public int IDLevel;
    public int currentLevel;
    public string starsLevel;
    public bool isUnlockSer = false;
    public HealthSystem healthSystem;
    public GameObject servantUnlock;
    public GameObject victoryPanel;
    public int ratingStar;
    public List<GameObject> UIStars;
    // Start is called before the first frame update
    public void WinGame()
    {
        RatingStar();
        if (isUnlockSer)
        {
            UnlockServant();
        }
        else
        {
            VictoryPanel();
        }
        PassLevel();
    }
    public int RatingStar()
    {

        if(healthSystem.defaultHealthCOunt == healthSystem.healthCount)
        {
            ratingStar = 3;
        }
        else if((float)healthSystem.healthCount/(float)healthSystem.defaultHealthCOunt > 0.5f)
        {
            ratingStar = 2;
        }
        else
        {
            ratingStar = 1;
        }
        return ratingStar;
    }

    public void UnlockServant()
    {
        servantUnlock.SetActive(true);
    }
    public void VictoryPanel()
    {
        if (servantUnlock.activeSelf)
        {
            isUnlockSer = false;
            servantUnlock.SetActive(false);
        }
        victoryPanel.SetActive(true);
        if (RatingStar() == 1)
        {
            UIStars[0].SetActive(true);
        }
        else if (RatingStar() == 2)
        {
            UIStars[1].SetActive(true);
        }
        else
        {
            UIStars[2].SetActive(true);
        }
    }
    //save & load
    public void SaveLevel()
    {
        SaveSystem.SaveLevel(this);
    }
    public void LoadLevel()
    {
        LevelData data = SaveSystem.LoadLevel();

    }
    public void PassLevel()
    {
        starsLevel = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(starsLevel, ratingStar);
        Debug.Log("currentLV" + currentLevel + ",lvISUnlock" + PlayerPrefs.GetInt("levelIsUnlocked"));
        if (currentLevel >= PlayerPrefs.GetInt("levelIsUnlocked"))
        {
            PlayerPrefs.SetInt("levelIsUnlocked", currentLevel + 1);
            
        }
    }
}
