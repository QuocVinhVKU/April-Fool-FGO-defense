using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public ParticleSystem laserStart;
    public ParticleSystem laserEnd;
    public float lineLengh = 10f;
    public LayerMask layerMask;
    private LineRenderer line;
    private bool sfxIsPlaying = false;
    private bool starPlaying = false;
    private bool endPlaying = false;
    private RaycastHit2D hit;
    public ArtoriaSanta dameArt;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void Shoot()
    {
        if (starPlaying == false)
        {
            starPlaying = true;
            laserStart.Play(true);
        }
        laserStart.gameObject.transform.position = transform.position;
        line.enabled = true;
        if (sfxIsPlaying == false)
        {
            sfxIsPlaying = true;
            
        }
        //hit = Physics2D.Raycast(transform.position, Vector2.right, lineLengh, layerMask);
        hit = Physics2D.Raycast(transform.position, Vector2.right, lineLengh, layerMask);
        if (hit)
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.LoseHealth(dameArt.attackDame);
            }
            
            if (endPlaying == false)
            {
                endPlaying = true;
                laserEnd.Play(true);
            }
            laserEnd.gameObject.transform.position = hit.point;
            float distance = ((Vector2)hit.point + new Vector2(1f, 1f) - (Vector2)transform.position).magnitude;
            line.SetPosition(1, new Vector3(distance, 0, 0));
        }
        else
        {
            line.SetPosition(1, new Vector3(lineLengh, 0, 0));
            endPlaying = false;
            laserEnd.Stop(true);
        }
    }
    public void notShoot()
    {
        line.SetPosition(1, new Vector3(lineLengh, 0, 0));
        endPlaying = false;
        laserEnd.Stop(true);
        starPlaying = false;
        laserStart.Stop(true);
        sfxIsPlaying = false;
        line.enabled = false;
    }
}
