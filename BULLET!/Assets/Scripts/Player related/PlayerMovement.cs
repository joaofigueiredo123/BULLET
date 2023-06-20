using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerSpeed = 425.0f;
    float jumpForce = 1230.0f;
    Rigidbody2D playerRb;
    [SerializeField] Vector2 movement;
    bool justJumped = false;
    bool facingRight = true;
    // SpriteRenderer playerSr;
    [SerializeField] LayerMask plataformPlayerMask;
    Collider2D playerCollider;
    AudioSource playerAudio;
    [SerializeField] AudioClip playerJumpSound;

    Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody2D>();
        // playerSr = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
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

    void FixedUpdate()
    {
        // Move player
        Move(movement);

        // Jump player
        if (justJumped)
        {
            playerAudio.PlayOneShot(playerJumpSound, 1.0f);
            Jump(movement);
        }
    }

    void Move(Vector2 direction)
    {
        playerRb.velocity = new Vector2(playerSpeed * direction.x * Time.deltaTime, playerRb.velocity.y);

    }

    void Jump(Vector2 direction)
    {
        justJumped = false;
        if (direction.y <= 0.6f)
        {
            direction.y = 0.6f;
        }
        playerRb.velocity = (Vector2.up * jumpForce * direction.y * Time.deltaTime);
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
        return groundRayCast.collider != null;
    }
}
