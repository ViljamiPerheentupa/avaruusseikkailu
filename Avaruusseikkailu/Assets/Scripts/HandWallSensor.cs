using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWallSensor : MonoBehaviour
{
    public Transform hoverpoint;
    public LayerMask wallLayer;
    public float maxDistance = 0.3f;
    void Update()
    {
        if (Physics.CheckSphere(hoverpoint.position, maxDistance, wallLayer)){
            GetComponent<PlayerHandMover>().canGrab = true;
            print("wall");
        } else GetComponent<PlayerHandMover>().canGrab = false;
    }
}
