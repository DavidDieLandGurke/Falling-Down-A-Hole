using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStanding : MonoBehaviour
{
    public Transform PlayerPosition;

    public float offset;

    void LateUpdate()
    {
        if(PlayerPosition.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, PlayerPosition.position.y, transform.position.z);
        }
    }
}
