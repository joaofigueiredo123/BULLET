using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth, health;
    void Start()
    {
        health = maxHealth;
        Debug.Log("Dummie current health: [" + health + "]");
    }

    public void TakeDamage(int damageAmmount)
    {
        health -= damageAmmount;
        Debug.Log("Dummie current health: [" + health + "]");
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy killed!");
        Destroy(gameObject);
    }
}
