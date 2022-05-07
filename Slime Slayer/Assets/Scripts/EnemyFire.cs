using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
 
    public Slime SlimeScript;
    public GameObject Player;

    public bool Alive;

    public GameObject bullet;

    float fireRate;

    public float fireRateMin = 10f;
    public float fireRateMax = 2f;
    float nextFire; 
    // Start is called before the first frame update
    void Start()
    {
        SlimeScript = Player.GetComponent<Slime>();
        
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(SlimeScript.PlayerAlive == true)
        {
            Check();
        }
        else
        {
            return;
        }
        
        
    }

    void Check() {
        if (Time.time > nextFire )
        {
            nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
            Instantiate(bullet, transform.position, Quaternion.identity );
            
        }
        else
        {
            return;
        }
    }
 
}
