using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public Animator animator;
    public void TakeHit(int damage)
    {
        health -= damage;
        animator.SetTrigger("CollisionDamage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
