using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int health, attackPower;
    public float moveSpeed;

    public Animator animator;
    public float attackTime;
    Coroutine attackOrder;
    Servant detectedServant;

    public BoxCollider2D boxColl;
    //public WaveSystem waveSystem;
    public Int numEnemyDie;
    private void Start()
    {
        
        boxColl = this.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (!detectedServant)
        {
            MoveForward();
        }
    }
    IEnumerator Attack()
    {
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(attackTime);
        animator.SetBool("attack", false);
        attackOrder = StartCoroutine(Attack());
    }
    public void InflicDamage()
    {
        if (detectedServant != null)
        {
            bool servantDie = detectedServant.LoseHealth(attackPower);
            if (servantDie)
            {
                detectedServant = null;
                StopCoroutine(attackOrder);
            }
        }

    }
    private void MoveForward()
    {
        animator.SetBool("attack", false);
        transform.Translate(- transform.right * moveSpeed * Time.deltaTime);
    }
    public void LoseHealth(int dame)
    {

        //dercease health
        health -= dame;
        //check if health is 0 -> call death anim and destroy enemy
        if (health <= 0 && this.gameObject.activeSelf)
        {
            TrueDeath();
        }
        //blink red anim
        if (health > 0 && this.gameObject.activeSelf)
        {
            StartCoroutine(BlinkRed());
        }
       
        
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
        numEnemyDie.value++;
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedServant)
        {
            return;
        }
        if(collision.tag == "Servant" && !collision.GetComponent<BoxCollider2D>().isTrigger)
        {
            detectedServant = collision.GetComponent<Servant>();
            attackOrder = StartCoroutine(Attack());
        }
    }

}
