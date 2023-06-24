using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float rotatingSpeed, verticalSpeed, horizontalSpeed;
    Vector3 initialPosition;
    [SerializeField] float topBoundry, bottomBoundry, leftBoundry, rightBoundry;
    bool verticalTurn = false;
    bool horizontalTurn = false;
    private void Start() {
        initialPosition = transform.position;
    }
    void Update()
    {
        transform.Rotate(0, 1 * rotatingSpeed * Time.deltaTime ,0);

        if (transform.position.y >= initialPosition.y + topBoundry)
        {
            verticalTurn = true;
        }
        else if (transform.position.y <= initialPosition.y - bottomBoundry)
        {
            verticalTurn = false;
        }

        if (!verticalTurn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (verticalSpeed * Time.deltaTime), transform.position.z);
        }
        else if (verticalTurn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (verticalSpeed * Time.deltaTime), transform.position.z);
        }

        if (transform.position.x >= initialPosition.x + rightBoundry)
        {
            horizontalTurn = true;
        }
        else if (transform.position.x <= initialPosition.x - leftBoundry)
        {
            horizontalTurn = false;
        }

        if (!horizontalTurn)
        {
            transform.position = new Vector3(transform.position.x + (horizontalSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else if (horizontalTurn)
        {
            transform.position = new Vector3(transform.position.x - (horizontalSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }
}
