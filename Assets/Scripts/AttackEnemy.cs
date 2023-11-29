using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform attackPointEnemy;
    public float attackRangeEnemy = 0.5f;
    public LayerMask playerLayers;

    public int attack_damage_enemy = 20;
    public float attack_rate_enemy = 2f;
    float next_attack_time = 0f;

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
}
