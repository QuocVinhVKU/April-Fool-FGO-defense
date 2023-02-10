using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    public TextMeshProUGUI textCurrency;
    public int defaultCurrency = 75;
    public int curency;
    public int quacGainPerSecond = 4;
    private void Start()
    {
        StartCoroutine(spawFreeQuac());
    }
    IEnumerator spawFreeQuac()
    {
        yield return new WaitForSeconds(3.2f);
        Gain(quacGainPerSecond);
        StartCoroutine(spawFreeQuac());
    }
    public void Init()
    {
        curency = defaultCurrency;
        UpdateUI();
    }
    public void Gain(int val)
    {
        curency += val;
        UpdateUI();
    }
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            curency -= val;
            UpdateUI();
            return true;
        }
        else
            return false;
    }
    public bool EnoughCurrency(int val)
    {
        if (val <= curency)
        {
            return true;
        }
        else
            return false;
    }
    void UpdateUI()
    {
        textCurrency.text = curency.ToString();
    }
    public void USETEST(){
        Debug.Log(Use(3));
    }
    public void GAINTEST()
    {
        //Debug.Log(Gain(2));
    }
}
