using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject playerReference;
    Player playerScriptReference;
    Vector3 initialCameraOffset;
    [SerializeField] float yAxisCameraOffset, zAxisCameraOffset, cameraOffsetTresholdX, cameraOffsetTresholdY;
    void Start()
    {
        playerReference = GameObject.Find("Player");
        playerScriptReference = playerReference.GetComponent<Player>();
        initialCameraOffset = new Vector3(0, yAxisCameraOffset, zAxisCameraOffset);
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
