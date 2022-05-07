using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int numberSpawn;
    public List<GameObject> Pool;
    public GameObject quad;
    public float spawnRate = 4f;
    float nextSpawn;



    Slime SlimeScript;
    public GameObject Player;
    public GameObject cloudM;
    public GameObject ratM;

    private GameObject gameObjects;
    public Transform ratS;
    public Transform cloudS;
    // Start is called before the first frame update
    void Start()
    {
        SlimeScript = Player.GetComponent<Slime>();
        SpawnEnemies();

    }

    public void SpawnEnemies()
    {
        //variables
        int randomEnemies = 0;
        GameObject toSpawn;
        float screenX, screenY;
        Vector2 pos;

        MeshCollider col = quad.GetComponent<MeshCollider>();

        for (int i = 0; i < numberSpawn; i++)
        {
            //chooses random enemies from the list
            randomEnemies = Random.Range(0, Pool.Count);
            toSpawn = Pool[randomEnemies];

            // finds the boundaries and position of spawn location
            screenX = Random.Range(col.bounds.min.x, col.bounds.max.x);
            screenY = Random.Range(col.bounds.min.y, col.bounds.max.y);
            pos = new Vector2(screenX, screenY);
            
            //Spawns the enemies
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SlimeScript.PlayerAlive == true)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                SpawnEnemies();
            }
            
            //InvokeRepeating("Cloud", 10f, 7f);
            //InvokeRepeating("Rat", 1f, 4f);
        }
        if (SlimeScript.PlayerAlive == false)
        {
            CancelInvoke("Cloud");
            CancelInvoke("Rat");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);

        }
    }

    
    public void Cloud()
    {
        Instantiate(cloudM, cloudS.position, Quaternion.identity);
    }
    public void Rat()
    {
        Instantiate(ratM, ratS.position, Quaternion.identity);
    }
}
