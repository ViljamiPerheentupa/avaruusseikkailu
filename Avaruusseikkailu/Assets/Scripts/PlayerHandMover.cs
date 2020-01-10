using System.Collections;
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
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    Vector3 lastPosition;
    Vector3 positionChange;
    public float speedMultiplier = 0.5f;
    Quaternion lastRotation;
    Quaternion rotationChange;

    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        rig = GetComponent<Rigidbody>();
        if (GetComponent<ConfigurableJoint>() != null) {
            joint = GetComponent<ConfigurableJoint>();
        }
    }

    
    void Update()
    {
        positionChange = transform.position - lastPosition;
        lastPosition = transform.position;
        bool grab = grabPinch.GetState(inputSource);
        if (grab) {
            print("grabbed");
            bodyRig.AddForce(-positionChange * speedMultiplier, ForceMode.VelocityChange);
        }
    }
    
    void BodyMove() {
        
    }
}
