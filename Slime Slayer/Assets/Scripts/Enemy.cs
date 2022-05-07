using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    
    public Counter KillCounter;
    public float speed;
    public float stoppingDistance = 6f;
    public float retreatDistance = 5f;
    public float maxHealth = 3f;
    public float curHealth;
    public HPBehavior HB;
    public GameObject bloodBurst;

    public Transform player;

    private void Start()
    {
        
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        curHealth = maxHealth;
        HB.SetHealth(curHealth, maxHealth);
    }

    private void Update()
    {
        this.spriteRenderer.flipX = this.transform.position.x < player.transform.position.x;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else
        {
            return;
        }
        
    }

    public void TakeDamage(float damage)
    {
        Instantiate(bloodBurst, transform.position, transform.rotation);

        curHealth -= damage;
        HB.SetHealth(curHealth, maxHealth);

        if (curHealth <= 0)
        {
            Counter.kcounter += 1;
            Destroy(gameObject);
        }
    }
}
