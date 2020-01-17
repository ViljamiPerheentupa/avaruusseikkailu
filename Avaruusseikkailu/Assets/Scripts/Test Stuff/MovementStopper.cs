using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovementStopper : MonoBehaviour
{
    public SteamVR_Action_Boolean grabGrip;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource;
    public float stopMultiplier = 1f;
    public float stopDeadzone = 0.1f;
    float stopXMove = 0;
    float stopYMove = 0;
    float stopZMove = 0;
    float stopYRot = 0;
    float stopXRot = 0;
    float stopZRot = 0;
    public Rigidbody bodyRig;
    public bool testing;
    GrabbableSensor sensor;

    public LayerMask layers;
    public Transform hand;
    public float wallRadius = 0.3f;

    private void Start() {
        sensor = GetComponent<GrabbableSensor>();
    }

    void Update()
    {
        bool grab = grabPinch.GetState(inputSource);

        if (sensor.grabbing) {
            if (grab) {
                StopMovement();
            }
        }
        if (!grab || !sensor.grabbing) {
            ResetStoppers();
        }
        if (testing) {
            bool stop = grabGrip.GetState(inputSource);
            if (stop) {
                StopMovement();
            }
            if (!stop) {
                ResetStoppers();
            }
        }
    }

    public void StopMovement() {
        
        if (bodyRig.velocity.x != 0) {
            stopXMove = bodyRig.velocity.x / (1 + Time.deltaTime) * stopMultiplier;
            if (stopXMove > 0 && stopXMove < stopDeadzone) {
                stopXMove = 0;
            }
            if (stopXMove < 0 && stopXMove > -stopDeadzone) {
                stopXMove = 0;
            }
        }
        if (bodyRig.velocity.y != 0) {
            stopYMove = bodyRig.velocity.y / (1 + Time.deltaTime) * stopMultiplier;
            if (stopYMove > 0 && stopYMove < stopDeadzone) {
                stopYMove = 0;
            }
            if (stopYMove < 0 && stopYMove > -stopDeadzone) {
                stopYMove = 0;
            }
        }
        if (bodyRig.velocity.z != 0) {
            stopZMove = bodyRig.velocity.z / (1 + Time.deltaTime) * stopMultiplier;
            if (stopZMove > 0 && stopZMove < stopDeadzone) {
                stopZMove = 0;
            }
            if (stopZMove < 0 && stopZMove > -stopDeadzone) {
                stopZMove = 0;
            }
        }
        if (bodyRig.angularVelocity.x != 0) {
            stopXRot = bodyRig.angularVelocity.x / (1 + Time.deltaTime) * stopMultiplier;
            if (stopXRot > 0 && stopXRot < stopDeadzone) {
                stopXRot = 0;
            }
            if (stopXRot < 0 && stopXRot > -stopDeadzone) {
                stopXRot = 0;
            }
        }
        if (bodyRig.angularVelocity.y != 0) {
            stopYRot = bodyRig.angularVelocity.y / (1 + Time.deltaTime) * stopMultiplier;
            if (stopYRot > 0 && stopYRot < stopDeadzone) {
                stopYRot = 0;
            }
            if (stopYRot < 0 && stopYRot > -stopDeadzone) {
                stopYRot = 0;
            }
        }
        if (bodyRig.angularVelocity.z != 0) {
            stopZRot = bodyRig.angularVelocity.z / (1 + Time.deltaTime) * stopMultiplier;
            if(stopZRot > 0 && stopZRot < stopDeadzone) {
                stopZRot = 0;
            }
            if (stopZRot < 0 && stopZRot > -stopDeadzone) {
                stopZRot = 0;
            }
        }
        bodyRig.velocity = new Vector3(stopXMove, stopYMove, stopZMove);
        bodyRig.angularVelocity = new Vector3(stopXRot, stopYRot, stopZRot);
    }

    public void ResetStoppers() {
        stopXMove = 0;
        stopXRot = 0;
        stopYMove = 0;
        stopYRot = 0;
        stopZMove = 0;
        stopZRot = 0;
    }
}
