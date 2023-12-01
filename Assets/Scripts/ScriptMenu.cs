using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    
    void OnClickStartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /*void OnClickCredits()
    {
        SceneManager.LoadScene("Creditos");
    }*/

    void OnClickExitGame()
    {
        Application.Quit();
    }
}
