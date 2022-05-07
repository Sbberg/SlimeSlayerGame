using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        PauseMenu.Paused = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Platform");
        Counter.kcounter = 0;
        PauseMenu.Paused = false;
    }
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
