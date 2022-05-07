using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWeapon : MonoBehaviour
{
    public Animator animator;
    public GameObject bullet;
    public Transform Gun;
    public float fireRate = 22f;
    public float speed = 5.0f;
    int damage = 1;
    public LayerMask whatToHit;

    public Transform TrailPrefab;
    float timeToFire;

    Vector2 Direction;
    float Angle;


    // Use this for initialization
    void Awake()
    {
        Gun = transform.Find("Shooter");
        if (Gun == null)
        {
            Debug.LogError("No Shooter for slime");
        }
    }

    void Update()
    {
        if (PauseMenu.Paused == false)
        {
            if (fireRate == 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {


                    Shoot();
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > timeToFire)
                {

                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }

        //Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

        //Gun.rotation = Quaternion.Euler(0, 0, Angle);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
        //    //Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        //    //Vector2 direction = target - myPos;
        //    //direction.Normalize();

        //    GameObject projectile = Instantiate(bullet);
        //    projectile.transform.position = Gun.position;
        //    projectile.transform.rotation = Quaternion.Euler(0, 0, Angle);

        //    projectile.GetComponent<Rigidbody2D>().velocity = Gun.right * speed;
        //}
    }
    void Shoot()
    {
        //Debug.Log("Shoot Works");
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 GunPosition = new Vector2(Gun.position.x, Gun.position.y);

        RaycastHit2D hit = Physics2D.Raycast (GunPosition, mousePosition - GunPosition, 100, whatToHit);

        Effect();
        Debug.DrawLine (GunPosition, (mousePosition-GunPosition)*100, Color.cyan);
        if (hit.collider !=null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Down!");
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Debug.DrawLine(GunPosition, hit.point, Color.red);
            Debug.Log("We hit" + hit.collider.name + "and did" + damage);
        }
        
    }
    void Effect()
    {
        Instantiate(TrailPrefab, Gun.position, Gun.rotation);
    }
}
