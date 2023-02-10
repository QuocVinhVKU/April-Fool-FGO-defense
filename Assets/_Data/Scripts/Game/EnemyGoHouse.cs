using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyGoHouse : MonoBehaviour
{
    public HealthSystem healthSys;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.isTrigger){

            other.GetComponent<Enemy>().TrueDeath();
            healthSys.LoseHealth();
        }
    }
}
