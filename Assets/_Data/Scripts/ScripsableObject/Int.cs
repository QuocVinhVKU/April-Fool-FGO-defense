using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Int : ScriptableObject
{
    // Editor value
    [SerializeField] private int resetValue = 0;          

    public int value;
    public float ResetValue { get { return resetValue; } }

    // Initialize coolDown with editor's value
    private void OnEnable()
    {
        value = resetValue;
    }

}
