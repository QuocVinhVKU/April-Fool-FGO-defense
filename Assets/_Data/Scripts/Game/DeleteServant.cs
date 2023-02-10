using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteServant : MonoBehaviour
{
    public BoolCanDelete boolCanDelete;
    public Image shove;
    private void Update()
    {
        if (boolCanDelete.canDelete)
        {
            shove.color = new Color(0.5f, 0.5f, 0.5f);

        }
        else
        {
            shove.color = new Color(1f, 1f, 1f);
        }
    }
    public void UseShove()
    {
        boolCanDelete.canDelete = !boolCanDelete.canDelete;
        
    }
}
