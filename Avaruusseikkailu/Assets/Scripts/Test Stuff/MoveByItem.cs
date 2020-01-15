using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MoveByItem : MonoBehaviour
{
    Rigidbody rig;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource;
    GameObject thrownItem;
    GameObject lastObject;
    public Rigidbody bodyRig;
    Vector3 thrownVelocity;
    bool throwOnce = true;
    public float throwVelocityMultiplier = 0.15f;

    private void Start() {
        rig = GetComponent<Rigidbody>();
    }
    void Update()
    {
        thrownItem = GetComponent<Hand>().currentAttachedObject;
        if (thrownItem != null) {
            lastObject = thrownItem;
            if (thrownItem.GetComponent<Rigidbody>() != null) {
                thrownItem.GetComponent<Rigidbody>().isKinematic = true;
            }
            throwOnce = true;
        }
        bool grab = grabPinch.GetState(inputSource);
        if (!grab && thrownItem != null) {
            thrownItem.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (lastObject != null) {
            thrownVelocity = lastObject.GetComponent<Rigidbody>().velocity;
        }
        if (!grab && thrownVelocity != Vector3.zero && throwOnce) {
            bodyRig.AddForce(-thrownVelocity * throwVelocityMultiplier, ForceMode.VelocityChange);
            lastObject = null;
            throwOnce = false;
        }
    }
}
