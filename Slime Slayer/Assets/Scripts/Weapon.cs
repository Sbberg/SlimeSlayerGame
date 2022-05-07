using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform Gun;
    public float speed = 5.0f;
    public LayerMask NotHit;

    Vector2 Direction;
    float Angle;


    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

        Gun.rotation = Quaternion.Euler(0, 0, Angle);

        if (Input.GetMouseButtonDown(0)) {
            //Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
            //Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            //Vector2 direction = target - myPos;
            //direction.Normalize();

            GameObject projectile = Instantiate(bullet);
            projectile.transform.position = Gun.position;
            projectile.transform.rotation = Quaternion.Euler(0, 0, Angle);

            projectile.GetComponent<Rigidbody2D>().velocity = Gun.right * speed;
        }
    }
}

    //public float offset;

    //public GameObject pro;
    //public Transform shotPoint;

    //private float timeBtwShots;
    //public float startTimeBtwShots;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

    //    if (timeBtwShots <= 0)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Instantiate(pro, shotPoint.position, transform.rotation);
    //            timeBtwShots = startTimeBtwShots;
    //        }
    //    }
    //    else {
    //        timeBtwShots -= Time.deltaTime;
    //    }
    //}

