using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float speed = 10f;
    public float life = 5f;
    public float distance = 5f;
    public float damage = 1;
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("DestroyProjectile", life);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Must");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
