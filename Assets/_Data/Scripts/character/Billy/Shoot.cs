using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float flySpeed;
    public Billy billy;
    [SerializeField] private float lifeTime = 3f;
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        FlyForward();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().LoseHealth(billy.dame);
            Destroy(this.gameObject);
        }
    }
    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }
}
