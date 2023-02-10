using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_attack : MonoBehaviour
{
    public Tower_Jack tower_Jack;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().LoseHealth(tower_Jack.jack_ATK);
        }
    }
    
}
