using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int total_hp = 100;
    int current_hp;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        current_hp = total_hp;
        healthBar.SetMaxHealth(total_hp);
    }

    public void take_damage_player(int damage)
    {
        current_hp -= damage;

        healthBar.SetHealth(current_hp);

        Debug.Log("hit");

        //animator.SetTrigger("Hurt");

        if (current_hp <= 0)
        {
            Morreu();
        }
    }

    void Morreu()
    {
        Debug.Log("Morreu");

        //animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
