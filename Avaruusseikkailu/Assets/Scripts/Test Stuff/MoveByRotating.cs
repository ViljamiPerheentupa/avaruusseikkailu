using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MoveByRotating : MonoBehaviour
{
    public Rigidbody bodyRig;
    public float deadzone;
    Quaternion lastRotation;
    Quaternion rotationChange;
    Vector3 rotationChangeEulers;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    bool doOnce = true;
    float distanceBetween;
    public float speed = 1;
    GrabbableSensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        lastRotation = transform.localRotation;
        sensor = GetComponent<GrabbableSensor>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grab = grabPinch.GetState(inputSource);

        if (sensor.grabbing) {
            if (!grab) {
                doOnce = true;
            }
            if (grab) {
                if (doOnce) {
                    distanceBetween = Vector3.Distance(transform.position, bodyRig.position);
                    lastRotation = transform.localRotation;
                    doOnce = false;
                    return;
                }
                rotationChange = Quaternion.Inverse(lastRotation) * transform.localRotation;
                lastRotation = transform.localRotation;
                bodyRig.rotation *= rotationChange;
            }
        }
    }
}
