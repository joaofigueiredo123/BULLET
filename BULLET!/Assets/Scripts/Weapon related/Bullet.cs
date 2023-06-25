using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    [SerializeField] float leftLimit, rightLimit, upLimit, downLimit;
    private void Start()
    {
    }
    private void Update()
    {
        if ((transform.position.x < leftLimit) || (transform.position.x > rightLimit) || (transform.position.y < downLimit) || (transform.position.y > upLimit))
        {
            Debug.Log("bullet went off boundries, destroying...");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyScript))
        {
            enemyScript.TakeDamage(damage);
        }

        Debug.Log("Bullet collided with " + other.gameObject.name);
        Destroy(gameObject);
    }

}
