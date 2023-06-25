using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject playerReference;
    [SerializeField] float angle, speed, distanceTrigger;
    float distance;
    Animator enemyAnim;
    Rigidbody2D enemyRb;
    Vector2 movement;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        playerReference = GameObject.Find("Player");

    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, playerReference.transform.position);
        Vector2 direction = playerReference.transform.position - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (!playerReference.GetComponent<Player>().isDead)
        {
            if (Mathf.Abs(angle) < 90)
            {
                angle = 0;
                movement = new Vector2(1, enemyRb.velocity.y);
            }
            else if (Mathf.Abs(angle) > 90)
            {
                angle = 180;
                movement = new Vector2(-1, enemyRb.velocity.y);
            }

            if (distance < distanceTrigger)
            {
                enemyAnim.SetBool("isWalking", true);
                enemyRb.velocity = movement * speed;
                // transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerReference.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.up * angle);
            }
            else
            {
                enemyAnim.SetBool("isWalking", false);
            }
        }
        else
        {
            movement = new Vector2(0,0);
            enemyAnim.SetBool("isWalking", false);
        }
    }
}
