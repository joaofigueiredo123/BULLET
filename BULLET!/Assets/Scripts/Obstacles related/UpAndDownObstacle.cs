using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownObstacle : MonoBehaviour
{
    [SerializeField] Transform startPoint, endPoint;
    [SerializeField] float speed;
    bool turn = false;
    void Start()
    {
        transform.position = startPoint.position;
    }

    void Update()
    {
        if (transform.position.y >= endPoint.position.y)
        {
            turn = true;
        }
        else if (transform.position.y <= startPoint.position.y)
        {
            turn = false;
        }

        if (!turn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
        }
        else if (turn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
        }
    }
}
