using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImput : MonoBehaviour
{
    public GameObject Projetil;

    private Mover characterMovement;
    float horizontal_move;
    float vertical_move;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attack_damage = 20;
    public float attack_rate = 2f;
    float next_attack_time = 0f;

    public Animator animator;

    private void Awake()
    {
        characterMovement = GetComponent<Mover>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal_move = Input.GetAxis("Horizontal");
        vertical_move = Input.GetAxis("Vertical");
        
        if (horizontal_move > 0 || vertical_move > 0)
        {
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }

        if (Time.time >= next_attack_time)
        {
            if (Input.GetKeyDown("j"))
            {
                Attack();
                next_attack_time = Time.time + 1f / attack_rate;
            }
            if (Input.GetKeyDown("space"))
            {
                // Cria uma nova bala na posiçao atual da nave para que siga a nave
                Instantiate(Projetil, transform.position, Quaternion.identity);
                next_attack_time = Time.time + 1f / attack_rate;
            }

        }
    }

    void Attack()
    {
        // animacao de ataque
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Inimigo>().take_damage(attack_damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void FixedUpdate()
    {
        characterMovement.Move(horizontal_move, vertical_move, false);
    }
}
