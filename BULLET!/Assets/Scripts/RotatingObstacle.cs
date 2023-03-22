using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    float sawRPS = 2.0f;
    void Update()
    {
        transform.Rotate(0, 0, -360.0f * sawRPS * Time.deltaTime);
    }
}
