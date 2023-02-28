using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerSpeed = 800.0f;
    float jumpForce =  200.0f;
    Rigidbody2D playerRb;
    Vector2 movement;
    float jumpInput;
    bool isGrounded = true;
    bool isJumping = false;
    bool facingRight = true;
    float maxVelocity = 5.0f;



    SpriteRenderer playerSr;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);

        jumpInput = Input.GetAxis("Vertical");

        if(jumpInput >= 0.95f){

            jumpInput = 1.0f;

        } else if (jumpInput < 0.15f){

            jumpInput = 0.15f;
            
        }

        if (Input.GetButtonUp("Jump")) {

            isJumping = true;

        }

        // Flip player
        Flip(CheckDirection());
    }

    void FixedUpdate() {
        // Move player
        Move(movement);

        // Jump player
        if (isJumping) {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){

            isGrounded = true;

        }
    }

    void Move(Vector2 direction){

        playerRb.AddForce(direction * playerSpeed * Time.deltaTime);

        CheckVelocity();
    }

    void Jump(){
        isJumping = false;
        isGrounded = false;
        playerRb.AddForce(Vector2.up * jumpInput * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    void Flip(bool orientation){
        playerSr.flipX = !orientation;
    }

    bool CheckDirection(){
        if(Input.GetKeyDown(KeyCode.A)){

            // Player is now facing LEFT
            facingRight = false;

        } else if (Input.GetKeyDown(KeyCode.D)){

            // Player is now facing RIGHT
            facingRight = true;

        }
        return facingRight;
    }

    void CheckVelocity(){
         if(playerRb.velocity.x >= maxVelocity) {

            playerRb.velocity = new Vector2 (maxVelocity, playerRb.velocity.y);

        } else if (playerRb.velocity.x <= -maxVelocity){

            playerRb.velocity = new Vector2 (-maxVelocity, playerRb.velocity.y);

        }       
    }
}
