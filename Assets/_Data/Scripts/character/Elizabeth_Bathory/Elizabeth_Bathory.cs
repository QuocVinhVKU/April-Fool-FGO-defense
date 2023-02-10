using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elizabeth_Bathory : Servant
{
    //so luong Quac tao ra
    public int incomeValue;
    //image Quac
    public GameObject quac;
    //animQUac
    public Animator anim_Quac;
    //cooldown tao Quac
    public float interval;
    protected override void Start()
    {
        StartCoroutine(Interval());
    }
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        //trigger the income increase
        IncreaseIncome();
        StartCoroutine(Interval());
    }
    public void IncreaseIncome()
    {
        GameManager.instance.currency.Gain(incomeValue);
        StartCoroutine(QuacIndication());
    }
    //Show Quac
    IEnumerator QuacIndication()
    {
        quac.SetActive(true);
        anim_Quac.SetBool("createQuac",true);
        yield return new WaitForSeconds(1f);
        quac.SetActive(false);
        anim_Quac.SetBool("createQuac", false);
    }

}
