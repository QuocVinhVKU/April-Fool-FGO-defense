using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelIsUnlocked;
    public GameObject[] levels;
    public string[] starLevels;
    public int[] stars;
    private void Start()
    {
        //PlayerPrefs.SetInt("levelIsUnlocked", 1);
        for (int i = 0; i < starLevels.Length - 1; i++)
        {
            stars[i] = PlayerPrefs.GetInt(starLevels[i]);
        }
        levelIsUnlocked = PlayerPrefs.GetInt("levelIsUnlocked", 1);
        for (int i = 0; i < levels.Length - 1; i++)
        {
            GetChildWithName(levels[i], "Level Locked").SetActive(true);
            GetChildWithName(levels[i], "Level Ready").SetActive(false);
            GetChildWithName(levels[i], "Stars_1").SetActive(false);
            GetChildWithName(levels[i], "Stars_2").SetActive(false);
            GetChildWithName(levels[i], "Stars_3").SetActive(false);
        }
        for (int i = 0; i < levelIsUnlocked; i++)
        {
            GetChildWithName(levels[i], "Level Locked").SetActive(false);
            
            GetChildWithName(levels[i], "Level Ready").SetActive(false);
            if (stars[i] == 1)
            {
                GetChildWithName(levels[i], "Stars_1").SetActive(true);
            }
            else if (stars[i] == 2)
            {
                GetChildWithName(levels[i], "Stars_2").SetActive(true);
            }
            else
            {
                GetChildWithName(levels[i], "Stars_3").SetActive(true);
            }
            if (i == levelIsUnlocked - 1) 
            {
                GetChildWithName(levels[i], "Level Ready").SetActive(true);
                GetChildWithName(levels[i], "Stars_1").SetActive(false);
                GetChildWithName(levels[i], "Stars_2").SetActive(false);
                GetChildWithName(levels[i], "Stars_3").SetActive(false);
            }
        }

    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null) {
            return childTrans.gameObject;
        } else
        {
            return null;
        }
    }
}
