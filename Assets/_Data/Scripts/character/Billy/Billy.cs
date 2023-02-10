using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billy : Servant
{
    public int dame;
    public GameObject prefab_shootItem;
    public float timeAttack;
    private float TimeAttack;
    private float lineLengh = 25f;
    public LayerMask layerMask;
    private RaycastHit2D hit;
    public AudioSource plantServant;

    private void Awake()
    {
        TimeAttack = timeAttack;
    }
    private void Update()
    {
        Attack();
        servantCanDelete = boolCanDelete.canDelete;
    }
    void Attack()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, lineLengh, layerMask);
        if (hit && CanShoot())
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
    bool CanShoot()
    {
        if(timeAttack <= 0)
        {
            timeAttack = TimeAttack;
            return true;
        }
        timeAttack -= Time.deltaTime;
        return false;
        
    }
    void ShootItem()
    {
        GameObject shootItem = Instantiate(prefab_shootItem, transform);
    }

}
