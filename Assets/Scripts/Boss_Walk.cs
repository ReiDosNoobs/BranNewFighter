using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 1.15f;
    //private float spawnRate = 6f;
    public int countAttack = 0;
    //public float time_rate = 2f;
    //float next_time = 0f;

    Transform player;
    Rigidbody2D rb;
    Flip boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Flip>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        Vector2 opPos = Vector2.MoveTowards(rb.position, target, -speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (countAttack >= 1)
        {
            rb.MovePosition(opPos);
            
            
            if (Vector2.Distance(player.position, rb.position) >= 4)
             {
                 countAttack = 0;
             }
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    /*private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);


        Debug.Log("dois ataque");
        rb.MovePosition(opPos);

        if (wait >= 5)
        {
            countAttack = 0;
        }
    }*/

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        countAttack = countAttack + 1;
        /*Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 opPos = Vector2.MoveTowards(rb.position, target, -speed * Time.fixedDeltaTime);
        rb.MovePosition(opPos);*/
    }
}
