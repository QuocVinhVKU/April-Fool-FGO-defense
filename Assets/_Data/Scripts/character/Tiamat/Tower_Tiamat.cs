using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Tiamat : Servant
{
    public override bool LoseHealth(int enemyDame)
    {
        health -= enemyDame;
        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("die", true);
            boxColl.enabled = false;
            StartCoroutine(Die());
            return true;
        }
        if (health > 0 && this.gameObject.activeSelf)
        {
            StartCoroutine(BlinkRed());
        }
        return false;
    }
    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
