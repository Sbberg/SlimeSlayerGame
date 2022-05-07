using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounterScreen : MonoBehaviour
{
    
    public Text Congrats;
    
    private static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = Counter.kcounter;
        Congrats.text = " Congrates you defeated " + score.ToString() + " Enemies! ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
