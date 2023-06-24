using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject playerReference;
    [SerializeField] float angle, speed, distanceTrigger;
    float distance;
    void Start()
    {
        playerReference = GameObject.Find("Player");
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, playerReference.transform.position);
        Vector2 direction = playerReference.transform.position - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceTrigger)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerReference.transform.position, speed * Time.deltaTime);
            // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
