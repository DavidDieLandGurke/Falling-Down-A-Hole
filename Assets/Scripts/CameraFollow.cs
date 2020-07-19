using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerPosition;
    public float offset;

    void Update()
    {
        transform.position = new Vector3(0, PlayerPosition.position.y + offset, -10);
    }
}
