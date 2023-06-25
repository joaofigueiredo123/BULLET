using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth, health;
    public int damage = 1;
    Animator enemyAnim;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        health = maxHealth;
        Debug.Log("Dummie current health: [" + health + "]");
    }

    public void TakeDamage(int damageAmmount)
    {
        enemyAnim.SetTrigger("isHurt");
        health -= damageAmmount;
        Debug.Log("Dummie current health: [" + health + "]");
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        HandleGameData.UpdateKillStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);
        
        Debug.Log("Enemy killed!");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("daohioa");
        }
    }
}
