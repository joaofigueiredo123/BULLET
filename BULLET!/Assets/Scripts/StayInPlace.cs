using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInPlace : MonoBehaviour
{
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
    }
}
