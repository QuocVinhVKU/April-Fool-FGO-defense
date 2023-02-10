using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public Animator giftAnim;
    public Victory victory;
    public void OpenGift()
    {   
        giftAnim.SetBool("open", true);
        StartCoroutine(DelayOpen());

    }
    private void OnMouseDown()
    {
        OpenGift();
    }
    IEnumerator DelayOpen()
    {
        yield return new WaitForSeconds(1f);
        victory.WinGame();
    }
}
