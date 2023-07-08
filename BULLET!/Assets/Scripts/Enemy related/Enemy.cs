using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth, health;
    public int damage = 1;
    Animator enemyAnim;
    public bool isDead = false;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        health = maxHealth;
    }

    public void TakeDamage(int damageAmmount)
    {
        enemyAnim.SetTrigger("isHurt");
        health -= damageAmmount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        HandleGameData.UpdateKillStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);
        isDead = true;
        Destroy(gameObject);
    }
}
