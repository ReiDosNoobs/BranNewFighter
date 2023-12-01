using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float vel_h = 4f;
    public float vel_v = 2.5f;
    public float movement_smooth = 0.1f;
    private Vector3 velocity = Vector3.zero;
    
    public Rigidbody2D rb;
    public Animator animator;
    private bool facing_right = true;
    private bool can_move = true;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PreventleavingScreen();

    }

    public void Move(float h_move, float v_move, bool jump)
    {
        if(can_move)
        {
            Vector3 targetVelocity = new Vector2(h_move * vel_h, v_move * vel_v);

            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movement_smooth);
            
            if(h_move >0 && !facing_right)
            {
                flip();
            } else if(h_move < 0 && facing_right)
            {
                flip();
            }
        }
    }

    private void flip()
    {
        facing_right = !facing_right;
        transform.Rotate(0, 180, 0);
        //GetComponent<Projetil>().Balinha(facing_right);
    }

    void PreventleavingScreen()
    {
        if (transform.position.x <= -5.5f || transform.position.x >= 43.5f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -5.5f, 43.5f);

            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        if (transform.position.y <= -3.9f || transform.position.y >= -0.5f)
        {
            float yPos = Mathf.Clamp(transform.position.y, -3.9f, -0.5f);

            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
}
