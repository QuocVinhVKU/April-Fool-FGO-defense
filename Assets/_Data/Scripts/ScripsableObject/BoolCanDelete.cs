using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BoolCanDelete : ScriptableObject
{
    // Editor value
    [SerializeField] private bool resetCanDelete = false;

    public bool canDelete = false;
    public bool ResetValue { get { return resetCanDelete; } }

    // Initialize coolDown with editor's value
    private void OnEnable()
    {
        canDelete = resetCanDelete;
    }

}
