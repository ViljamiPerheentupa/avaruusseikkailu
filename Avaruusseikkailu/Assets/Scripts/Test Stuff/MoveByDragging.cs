using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MoveByDragging : MonoBehaviour
{
    Vector3 lastPosition;
    Vector3 changePosition;
    public Rigidbody bodyRig;
    public float deadzone = 0.3f;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource;
    Interactable environment;
    public float dragSpeedMultiplier = 2;


    void Start()
    {
        lastPosition = transform.position;
    }

    
    void Update()
    {
        bool grab = grabPinch.GetState(inputSource);
        changePosition = transform.position - lastPosition;
        lastPosition = transform.position;
        if (grab) {
            print(Vector3.Distance(transform.position + changePosition, transform.position));
            if (Vector3.Distance(transform.position + changePosition, transform.position) * dragSpeedMultiplier > deadzone) {
                bodyRig.AddForce(-changePosition * dragSpeedMultiplier, ForceMode.VelocityChange);
            }
        }
    }
}
