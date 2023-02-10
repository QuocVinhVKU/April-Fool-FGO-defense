using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecchanAttack : MonoBehaviour
{
    public Ecchan ecchan;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().LoseHealth(ecchan.dame);
        }
    }

}
