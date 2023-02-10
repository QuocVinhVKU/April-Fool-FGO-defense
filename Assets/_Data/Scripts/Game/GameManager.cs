using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        //Time.timeScale = 4f;
        instance = this;
    }

    public Spawer spawer;
    public HealthSystem health;
    public CurrencySystem currency;
    private void Start()
    {
        GetComponent<HealthSystem>().Init();
        GetComponent<CurrencySystem>().Init();
        //StartCoroutine(WaveStartDelay());
    }
    
}
