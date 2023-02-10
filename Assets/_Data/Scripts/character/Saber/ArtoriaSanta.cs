using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtoriaSanta : Servant
{
    public int attackDame;
    public LaserController laser;
    private float lineLengh = 25f;
    public LayerMask layerMask;
    private RaycastHit2D hit;
    private void Update()
    {
        Excalibur();
        servantCanDelete = boolCanDelete.canDelete;
    }
    void Excalibur()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, lineLengh, layerMask);
        if (hit)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
    public void Shoot()
    {
        laser.Shoot();
    }
    public void notShoot()
    {
        laser.notShoot();
    }

}
