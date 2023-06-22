using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth, health;
    PlayerUICanvasHandler playerUI;
    Rigidbody2D playerRb;
    Animator playerAnim;

    public bool isDead = false;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        playerUI = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacleScript))
        {
            TakeDamage(obstacleScript.damage);
        }

        Debug.Log("player collided with: " + collision.gameObject.name);
    }

    public void TakeDamage(int damageAmmount)
    {

        health -= damageAmmount;

        playerUI.UpdateHealthCount(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        playerAnim.SetBool("isDead", true);
        playerUI.GameOver();
        Debug.Log("Player is now, DEAD!");
        Destroy(GameObject.Find("Hand"));
    }

}
