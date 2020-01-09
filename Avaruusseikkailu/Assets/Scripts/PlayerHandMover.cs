﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class PlayerHandMover : MonoBehaviour
{
    Rigidbody rig;
    ConfigurableJoint joint;
    bool isLatched = false;
    public Rigidbody bodyRig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        if (GetComponent<ConfigurableJoint>() != null) {
            joint = GetComponent<ConfigurableJoint>();
        }
    }

    
    void Update()
    {
        BodyMove();
    }
    
    void BodyMove() {
        //if (isLatched) {
            bodyRig.AddForce(-rig.velocity / 2, ForceMode.VelocityChange);
        //}
    }
}
