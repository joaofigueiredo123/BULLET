using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyScript))
        {
            enemyScript.TakeDamage(damage);
        }
        // Debug.Log("Bullet collided with " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
