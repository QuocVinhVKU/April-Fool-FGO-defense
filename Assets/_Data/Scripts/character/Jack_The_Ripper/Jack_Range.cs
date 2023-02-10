using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Range : MonoBehaviour
{
    public Tower_Jack jack;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            jack.animator.SetBool("attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            jack.animator.SetBool("attack", false);
        }
    }
}
