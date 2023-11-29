using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float speed = 6f;
    //private bool right_left;

    // Start is called before the first frame update
    public void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        //Balinha();
    }

    public void Balinha(/*bool facing_right*/)
    {
        /*if (facing_right == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(speed, 0);
        //}
        else if (facing_right == false)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-speed, 0);
        }*/
    }
    void OnBecameInvisible()
    {
        // Destroi a bala quando já está fora da tela
        Destroy(gameObject);
    }
}
