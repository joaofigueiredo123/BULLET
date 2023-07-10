using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerSpeed = 385.0f;
    float jumpForce = 1260.0f;
    Rigidbody2D playerRb;
    [SerializeField] Vector2 movement, jumpDirection;
    bool justJumped = false;
    bool facingRight = true;
    [SerializeField] LayerMask plataformPlayerMask, groundPlayerMask, bossPlayerMask, zombiePlayerMask;
    Collider2D playerCollider;
    AudioSource playerAudio;
    [SerializeField] AudioClip playerJumpSound;
    Player playerInstance;
    Animator playerAnim;
    [SerializeField] public float speedMultiplier = 1.0f, speedUpgrade;

    void Start()
    {
        playerInstance = GetComponent<Player>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!playerInstance.isDead)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));

            if (!justJumped && Input.GetButtonUp("Jump") && IsGrounded())
            {
                justJumped = true;

            }

            if (movement.x == 0)
            {
                playerAnim.SetBool("isWalking", false);
            }
            else
            {
                playerAnim.SetBool("isWalking", true);
            }

            // Flip player
            CheckDirection();
        }
    }

    void FixedUpdate()
    {
        if (!playerInstance.isDead)
        {
            // Move player
            Move(movement);

            // Jump player
            if (justJumped)
            {
                playerAudio.PlayOneShot(playerJumpSound, 0.4f);
                Jump(movement);
            }
        }
    }

    void Move(Vector2 direction)
    {
        playerRb.velocity = new Vector2(playerSpeed * direction.x * speedMultiplier * (1 + (speedUpgrade * 0.0515f)) * Time.deltaTime, playerRb.velocity.y);

    }

    void Jump(Vector2 direction)
    {
        justJumped = false;
        if (direction.y <= 0.6f)
        {
            direction.y = 0.6f;
        }
        playerRb.velocity = (jumpDirection * jumpForce * direction.y * Time.deltaTime);

        HandleGameData.UpdateJumpStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    bool CheckDirection()
    {
        if (Input.GetKeyDown(KeyCode.A) && facingRight)
        {
            // Player is now facing LEFT
            Flip();
            facingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !facingRight)
        {
            // Player is now facing RIGHT
            Flip();
            facingRight = true;

        }
        return facingRight;
    }

    bool IsGrounded()
    {
        RaycastHit2D groundRayCast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, plataformPlayerMask);
        if (groundRayCast.collider == null)
        {
            groundRayCast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, groundPlayerMask);
        }
        if (groundRayCast.collider == null)
        {
            groundRayCast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, bossPlayerMask);
        }
        if (groundRayCast.collider == null)
        {
            groundRayCast = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, zombiePlayerMask);
        }
        return groundRayCast.collider != null;
    }
}
