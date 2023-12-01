using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform attackPointEnemy;
    public float attackRangeEnemy = 0.5f;
    public LayerMask playerLayers;

    public int attack_damage_enemy = 5;
    public float attack_rate_enemy = 2f;
    float next_attack_time = 0f;

    void Update()
    {
        PreventleavingScreen();
    }
    
    public void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPointEnemy.position, attackRangeEnemy, playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().take_damage_player(attack_damage_enemy);
        }
        next_attack_time = Time.time + 1f / attack_rate_enemy;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPointEnemy == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPointEnemy.position, attackRangeEnemy);
    }

    void PreventleavingScreen()
    {
        if (transform.position.x <= -8.0f || transform.position.x >= 65.0f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -8.0f, 65.0f);

            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        if (transform.position.y <= -5.5f || transform.position.y >= -0.6f)
        {
            float yPos = Mathf.Clamp(transform.position.y, -5.5f, -0.6f);

            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
}
