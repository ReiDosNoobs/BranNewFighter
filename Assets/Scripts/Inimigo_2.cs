using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_2 : MonoBehaviour
{
    public int total_hp = 75;
    int current_hp;
    private int attack_damage_p = 40;
    public int valor = 0;
    public int valor_ini = 50;
    public int valor_ini_2 = 100;

    private PointScript ptScript;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        current_hp = total_hp;
        ptScript = GameObject.Find("Pontuacao").GetComponent<PointScript>();
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "projetilTag")
        {
            take_damage(attack_damage_p);
            Destroy(outro.gameObject);

            ptScript.pontos += valor_ini;
        }
    }

    public void take_damage(int damage)
    {
        current_hp = current_hp - (damage * 2);

        Debug.Log("hit");

        animator.SetTrigger("Hurt");

        if (current_hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Morreu");

        animator.SetBool("IsDead", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Morreu();
    }

    void Morreu()
    {
        ptScript.pontos += valor_ini_2;

        Destroy(this.gameObject);
    }
}
