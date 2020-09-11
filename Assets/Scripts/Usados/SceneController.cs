using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float timer;
    public bool isSplash;

    void Update()
    {
        if (isSplash)
        {
            timer -= Time.deltaTime;

            if (timer <= 2)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}      
