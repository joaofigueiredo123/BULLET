using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth, health;
    PlayerUICanvasHandler playerUI;
    Rigidbody2D playerRb;
    Animator playerAnim;
    [SerializeField] AudioClip gameOverSound, damageSound;
    AudioSource playerSoundSource;

    public bool isDead = false;
    bool tookDamage = false;

    void Start()
    {
        Time.timeScale = 1.0f;
        playerSoundSource = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        playerUI = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        health = maxHealth;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDead && !tookDamage)
        {
            if (collision.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacleScript))
            {
                StartCoroutine(TakeDamage(obstacleScript.damage));
            }

            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyScript))
            {

                StartCoroutine(TakeDamage(enemyScript.damage));
            }
        }
    }

    IEnumerator TakeDamage(int damageAmmount)
    {
        tookDamage = true;
        playerSoundSource.PlayOneShot(damageSound, 1f);

        health -= damageAmmount;

        playerUI.UpdateHealthCount(health);

        if (health <= 0)
        {
            Die();
        }
        yield return new WaitForSecondsRealtime(2.10f);
        tookDamage = false;
    }

    void Die()
    {
        if (!isDead)
        {
            playerSoundSource.PlayOneShot(gameOverSound, 0.8f);
        }
        GetComponent<PlayerMovement>().enabled = false;
        playerRb.velocity = Vector2.zero;
        playerRb.angularVelocity = 0f;
        isDead = true;
        playerAnim.SetBool("isDead", true);
        playerUI.GameOver();
        Destroy(GameObject.Find("Hand"));

        HandleGameData.UpdateDeathStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);
    }
}
