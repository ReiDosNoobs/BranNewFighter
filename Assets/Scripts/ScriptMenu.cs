using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    /*private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;*/

    // Update is called once per frame
    void Update()
    {
        AbrirCreditos();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        /*Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);*/
    }

    void AbrirCreditos()
    {
        if(Input.GetKeyDown("c"))
        {
        SceneManager.LoadScene("Creditos");
        }
        if (Input.GetKeyDown("j"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown("s"))
        {
            Application.Quit();
        }
    }

}
