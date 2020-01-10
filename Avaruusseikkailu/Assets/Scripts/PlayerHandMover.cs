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
    float rotationX;
    float rotationY;
    float rotationZ;
    float rotationW;
    float newRotationX;
    float newRotationY;
    float newRotationZ;
    float newRotationW;
    public float rotationMultiplier = 0.5f;

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
        GetLastRotationValues();
        lastRotation = transform.rotation;
        GetNewRotationValues();
        GetRotationChange();
        rotationChange = new Quaternion(rotationX, rotationY, rotationZ, rotationW);
        positionChange = transform.position - lastPosition;
        lastPosition = transform.position;
        bool grab = grabPinch.GetState(inputSource);
        BodyMove(grab);
    }
    
    void BodyMove(bool grab) {
        if (grab) {
            print("grabbed");
            bodyRig.AddForce(-positionChange * speedMultiplier, ForceMode.VelocityChange);
            bodyRig.MoveRotation(rotationChange);
        }
    }

    void GetRotationChange() {
        rotationX = (newRotationX - rotationX) * rotationMultiplier;
        rotationY = (newRotationY - rotationY) * rotationMultiplier;
        rotationZ = (newRotationZ - rotationZ) * rotationMultiplier;
        rotationW = (newRotationW - rotationW) * rotationMultiplier;
    }

    void GetLastRotationValues() {
        rotationX = lastRotation.x;
        rotationY = lastRotation.y;
        rotationZ = lastRotation.z;
        rotationW = lastRotation.w;
    }
    void GetNewRotationValues() {
        newRotationX = lastRotation.x;
        newRotationY = lastRotation.y;
        newRotationZ = lastRotation.z;
        newRotationW = lastRotation.w;
    }
}
