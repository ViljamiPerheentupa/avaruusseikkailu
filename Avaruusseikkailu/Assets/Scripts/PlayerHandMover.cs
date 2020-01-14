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
    public float rotationMultiplier = 0.5f;
    Vector3 anchorPoint;
    bool anchorOnce = true;

    //Rotation
    public Transform attachPoint;
    public float inertiaMultiplier = 0.2f;
    public float inertiaTimerMultiplier = 0.33f;
    public float rotationDeadzone = 1f;
    float inertiaTimer = 0;
    bool doOnce = true;

    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.localRotation;
        rig = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        bool grab = grabPinch.GetState(inputSource);
        rotationChange = Quaternion.Inverse(lastRotation) * transform.localRotation;
        lastRotation = transform.localRotation;
        positionChange = transform.position - lastPosition;
        lastPosition = transform.position;
        //if (grab) {
        //    bodyRig.velocity = Vector3.zero;
        //}
        BodyMove(grab);
        BodyRotate(grab);
    }

    void AnchorHand() {
        if (anchorOnce) {
            anchorPoint = rig.position;
            anchorOnce = false;
        }
        rig.position = anchorPoint;

    }
    
    void BodyMove(bool grab) {
        if (grab) {
            bodyRig.AddForce(-positionChange * speedMultiplier, ForceMode.VelocityChange);
            //bodyRig.rotation = bodyRig.rotation * rotationChange;
        }
    }

    void BodyRotate(bool grab) {
        if (grab) {
            if (doOnce) {
                attachPoint.position = bodyRig.position;
                doOnce = false;
            }
            if (HasRotated()) {
                if (inertiaTimer < 1) {
                    inertiaTimer += Time.deltaTime * inertiaTimerMultiplier;
                }
                if (inertiaTimer >= 1) {
                    inertiaTimer = 1;
                }
                bodyRig.position += (attachPoint.position - bodyRig.transform.position) * inertiaTimer * inertiaMultiplier;
            }
        }
        if (!grab) {
            inertiaTimer = 0;
            doOnce = true;
            anchorOnce = true;
        }
    }

    bool HasRotated() {
        if (Vector3.Distance(attachPoint.position, bodyRig.transform.position) > rotationDeadzone) {
            return true;
        } else return false;
    }
}
