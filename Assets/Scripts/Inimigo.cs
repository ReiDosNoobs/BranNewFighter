using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int total_hp = 100;
    int current_hp;
    private int attack_damage_p = 50;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        current_hp = total_hp;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "projetilTag")
        {
            take_damage(attack_damage_p);
            Destroy(outro.gameObject);
        }
    }
      
    public void take_damage(int damage)
    {
        current_hp -= damage;

        Debug.Log("hit");

        //animator.SetTrigger("Hurt");

        if(current_hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Morreu");

        //animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(this.gameObject);
    }
}
