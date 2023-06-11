using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject playerReference;
    Player playerScriptReference;
    Vector3 initialCameraOffset;
    float cameraOffsetTresholdX = 3.0f;
    float cameraOffsetTresholdY = 3.0f;
    [SerializeField] float xAxisCameraOffset = 0.0f;
    [SerializeField] float yAxisCameraOffset = 5.0f;
    [SerializeField] float zAxisCameraOffset = -6.0f;
    void Start()
    {
        playerScriptReference = playerReference.GetComponent<Player>();
        initialCameraOffset = new Vector3(xAxisCameraOffset, yAxisCameraOffset, zAxisCameraOffset);
        transform.position = playerReference.transform.position + initialCameraOffset;
    }

    void Update()
    {
        if (!playerScriptReference.isDead)
        {
            HandleCameraMovementX();
            HandleCameraMovementY();
        }
    }

    void HandleCameraMovementX()
    {

        if (playerReference.transform.position.x - transform.position.x > cameraOffsetTresholdX)
        {

            transform.position = new Vector3(playerReference.transform.position.x - cameraOffsetTresholdX, transform.position.y, transform.position.z);

        }
        else if (playerReference.transform.position.x - transform.position.x < -cameraOffsetTresholdX)
        {

            transform.position = new Vector3(playerReference.transform.position.x + cameraOffsetTresholdX, transform.position.y, transform.position.z);

        }
    }
    void HandleCameraMovementY()
    {

        if (playerReference.transform.position.y - transform.position.y > cameraOffsetTresholdY)
        {

            transform.position = new Vector3(transform.position.x, playerReference.transform.position.y - cameraOffsetTresholdY, transform.position.z);

        }
        else if (playerReference.transform.position.y - transform.position.y < -cameraOffsetTresholdY)
        {

            transform.position = new Vector3(transform.position.x, playerReference.transform.position.y + cameraOffsetTresholdY, transform.position.z);

        }
    }
}
