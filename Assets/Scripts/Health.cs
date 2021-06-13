using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameObject player;
    public int health;
    public Animator animator;
    public void TakeHit(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            animator.SetTrigger("CollisionDamage");
            if (health <= 0)
            {
                health = 0;
                if (gameObject.CompareTag("Enemy"))
                    Destroy(gameObject);
                if (gameObject.CompareTag("Player"))
                {
                    player = GameObject.FindWithTag("Player");
                    var speitw = player.GetComponent<Animator>();
                    speitw.SetTrigger("Death");
                }
            }
        }
    }
    public void Stoptime()
    {
        Time.timeScale = 0f;    
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health>100)
        {
            health = 100;
        }
    }
}
