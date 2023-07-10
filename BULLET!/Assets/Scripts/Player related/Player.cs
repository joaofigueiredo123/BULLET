using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth, health;
    PlayerUICanvasHandler playerUI;
    PowerupTimer powerupTimer;
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
        powerupTimer = GameObject.Find("PlayerUICanvas").GetComponent<PowerupTimer>();
        maxHealth = 3 + GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade1_level;
        health = maxHealth;
        playerUI.UpdateContainers(health);
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
        yield return new WaitForSeconds(2.10f);
        tookDamage = false;
    }

    void Die()
    {
        if (!isDead)
        {
            playerSoundSource.PlayOneShot(gameOverSound, 0.8f);
        }
        isDead = true;
        GetComponent<PlayerMovement>().enabled = false;
        playerRb.velocity = new Vector2(0,0);
        playerRb.angularVelocity = 0f;
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionY;
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerAnim.SetBool("isDead", true);
        powerupTimer.timerOn = false;
        playerUI.GameOver();
        Destroy(GameObject.Find("Hand"));

        HandleGameData.UpdateDeathStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);
        GetComponent<Player>().enabled = false;
    }
}
