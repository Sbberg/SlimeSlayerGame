using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Counter : MonoBehaviour
{
    GameObject[] enemies;
    public Text countText;
    public static int kcounter = 0;
    public Text EnemykText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        countText.text = "Enemies : " + enemies.Length.ToString();

        EnemykText.text = "Enemies Defeated : " + kcounter.ToString();
    }
}
