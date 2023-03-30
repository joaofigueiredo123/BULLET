using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth, health;
    Rigidbody2D playerRb;
    public bool isDead = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<RotatingObstacle>(out RotatingObstacle rotatingObstacleScript))
        {
            Die();
        }
    }

    public void TakeDamage(int damageAmmount)
    {

        health -= damageAmmount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player is now, DEAD!");
        isDead = true;
        Destroy(gameObject);
    }
}
