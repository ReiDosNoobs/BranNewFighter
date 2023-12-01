using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Animator animator;
    public float speed = 6f;
    private PointScript ptScript;

    // Start is called before the first frame update
    public void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);

        ptScript = GameObject.Find("Pontuacao").GetComponent<PointScript>();
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "balaTag")
        {
            Destroy(outro.gameObject);
            Destroy(this.gameObject);
            ptScript.pontos+= 10;
        }
    }

void OnBecameInvisible()
    {
        // Destroi a bala quando já está fora da tela
        Destroy(gameObject);
    }
}
