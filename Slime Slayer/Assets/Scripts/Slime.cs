using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slime : MonoBehaviour
{

    [SerializeField]
    private float invincibilityDurationSeconds = 1f;
    public bool isInvincible = false;
    private float invincibilityDeltaTime = .5f;

    private SpriteRenderer sprite;
    public Animator anim;
    public bool PlayerAlive = true;
    public HPBehavior HB;
    
    public static float healthAmount = 1f;
    public float currentHealth;

    public float speed = 5f;
    float moveHorizon;
    private Rigidbody2D rb2d;
    //public Image img;

    public float jump = 5f;
    public bool canJump = false;
    public bool facingRight;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = healthAmount;
        HB.SetHealth(currentHealth, healthAmount);
    }


    void FixedUpdate()
    {
        

        float moveHorizon = Input.GetAxis("Horizontal") * speed;
        //float moveVertical = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", Mathf.Abs( moveHorizon));

       Vector2 movement = moveHorizon * Vector2.right;
        rb2d.AddForce(movement * speed);

        Vector3 characterScale = transform.localScale;

        

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(sprite != null)
            {
                sprite.flipX = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // flip the sprite
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            rb2d.AddForce(transform.up * jump);
            Debug.Log("Help");
            canJump = false;
           
        }
        if (canJump == false)
        {
            anim.SetBool("Ground", false);
        }
        else
        {
            anim.SetBool("Ground", true);
        }

            //SceneManager.LoadScene("GameOver");
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            LoseHealth();



        }
        if (collision.gameObject.tag == "EnemyFire")
        {
            LoseHealth();
          

        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        LoseHealth();
        
        
    }


    private IEnumerator Invin()
    {
        // sets invincibility
        Debug.Log("Took an arrow to the knee");
        isInvincible = true;

        //timer until invincibility is up
        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {

            yield return new WaitForSeconds(invincibilityDeltaTime);
        }
        //ends invincibility
        Debug.Log("Did somebody steal your sweet roll");
        isInvincible = false;
    }
    public void LoseHealth()
    {
        //nothing happens
        if (isInvincible) return;
        
        //takes damage
        currentHealth -= .1f;
        HB.SetHealth(currentHealth, healthAmount);

        //starts invincibility
        if (currentHealth <= 0)
        {
            PlayerAlive = false;
            Destroy(this.gameObject);
            SceneManager.LoadScene("Win");
            
            
            return;
        }
        StartCoroutine(Invin());

    }
}
