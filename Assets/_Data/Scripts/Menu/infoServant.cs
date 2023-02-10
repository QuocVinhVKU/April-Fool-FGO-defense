using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class infoServant : MonoBehaviour
{
    public GameObject serPrefabs;
    public Image faceSer;
    // Start is called before the first frame update
    void Start()
    {
        faceSer.sprite = serPrefabs.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
