using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
