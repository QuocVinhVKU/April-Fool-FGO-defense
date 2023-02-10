using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servant : MonoBehaviour
{
    public BoolCanDelete boolCanDelete;
    public int health;
    public int cost;
    public BoxCollider2D boxColl;
    public Animator animator;
    public bool servantCanDelete;

    public Vector3Int cellPosition;
    protected virtual void Start()
    {
        animator = this.GetComponent<Animator>();
        boxColl = this.GetComponent<BoxCollider2D>();
        //Debug.Log("base");
    }
    private void Update()
    {
        servantCanDelete = boolCanDelete.canDelete;
        
    }
    private void OnMouseDown()
    {
        if (servantCanDelete)
        {
            TrueDeath();
            boolCanDelete.canDelete = false;
        }
    }
    public virtual void Init(Vector3Int cellPos)
    {
        cellPosition = cellPos;
    }
    public virtual bool LoseHealth(int enemyDame)
    {
        health -= enemyDame;
        if (health <= 0)
        {
            boxColl.enabled = false;
            TrueDeath();
            return true;
        }
        if (health > 0 && this.gameObject.activeSelf)
        {
            StartCoroutine(BlinkRed());
        }
        return false;
    }
    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void TrueDeath()
    {
        StartCoroutine(Die());
    }
    public IEnumerator Die()
    {
        //GetComponent<Animator>().SetBool("die", true);
        yield return new WaitForSeconds(0.01f);
        FindObjectOfType<Spawer>().RevertCellState(cellPosition);
        Destroy(gameObject);
    }
}
