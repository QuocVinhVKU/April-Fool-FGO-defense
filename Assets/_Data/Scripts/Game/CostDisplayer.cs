using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostDisplayer : MonoBehaviour
{
    public int towerID;
    public int towerCost;
    public TextMeshProUGUI txt_towerCost;
    void Start()
    {
        towerCost = GameManager.instance.spawer.TowerCost(towerID);
        txt_towerCost.text = towerCost.ToString();
    }

}
