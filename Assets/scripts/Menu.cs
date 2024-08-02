using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
    public void Appmenu()
    {
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayApp()
    {
        SceneManager.LoadScene(1);
       // SceneManager.LoadScene("Level1");
    }
    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("Çýkýþ Yapýldý");
    }
}
