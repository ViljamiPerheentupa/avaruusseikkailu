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
    bool anchorOnce = true;
    public bool canGrab = false;
    float stopXMove = 0;
    float stopYMove = 0;
    float stopZMove = 0;
    float stopYRot = 0;
    float stopXRot = 0;
    float stopZRot = 0;

    //Rotation
    public Transform attachPoint;
    public float inertiaMultiplier = 0.2f;
    public float inertiaTimerMultiplier = 0.33f;
    public float rotationDeadzone = 1f;
    float inertiaTimer = 0;
    bool doOnce = true;
    public Transform anchorPoint;

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
        if (canGrab) {
            AnchorHand(grab);
            BodyRotate(grab);
            if (!HasRotated()) {
                BodyMove(grab);
            }
        }
        if (!grab) {
            inertiaTimer = 0;
            doOnce = true;
            anchorOnce = true;
        }
    }

    void StopMovement() {
        if (bodyRig.velocity.x != 0) {
            if (bodyRig.velocity.x < 0) {
                stopXMove += Time.deltaTime;
            } else stopXMove -= Time.deltaTime;
        }
        if (bodyRig.velocity.y != 0) {
            if (bodyRig.velocity.y < 0) {
                stopYMove += Time.deltaTime;
            } else stopYMove -= Time.deltaTime;
        }
        if (bodyRig.velocity.z != 0) {
            if (bodyRig.velocity.z < 0) {
                stopZMove += Time.deltaTime;
            } else stopZMove -= Time.deltaTime;
        }
        if (bodyRig.angularVelocity.x != 0) {
            if (bodyRig.angularVelocity.x < 0) {
                stopXRot += Time.deltaTime;
            } else stopXRot -= Time.deltaTime;
        }
        if (bodyRig.angularVelocity.y != 0) {
            if (bodyRig.angularVelocity.y < 0) {
                stopYRot += Time.deltaTime;
            } else stopYRot -= Time.deltaTime;
        }
        if (bodyRig.angularVelocity.z < 0) {
            if (bodyRig.angularVelocity.z < 0) {
                stopZRot += Time.deltaTime;
            } else stopZRot -= Time.deltaTime;
        }
        bodyRig.velocity += new Vector3(stopXMove, stopYMove, stopZMove);
        bodyRig.angularVelocity += new Vector3(stopXRot, stopYRot, stopZRot);
    }

    void AnchorHand(bool grab) {
        if (grab) {
            if (anchorOnce) {
                if (bodyRig.velocity != Vector3.zero && bodyRig.angularVelocity != Vector3.zero) {
                    StopMovement();
                }
                if (Vector3.Distance(bodyRig.position, anchorPoint.position) > Vector3.Distance(anchorPoint.position, attachPoint.position)) {
                    bodyRig.velocity = Vector3.zero;
                    bodyRig.angularVelocity = Vector3.zero;
                }
                anchorOnce = false;
            }
            return;
        } else return;
    }
    
    void BodyMove(bool grab) {
        if (grab) {
            bodyRig.AddForce(-positionChange * speedMultiplier, ForceMode.VelocityChange);
            //bodyRig.rotation = bodyRig.rotation * rotationChange;
            return;
        } else return;
    }

    void BodyRotate(bool grab) {
        if (grab) {
            if (doOnce) {
                anchorPoint.position = transform.position;
                attachPoint.position = bodyRig.transform.position;
                rig.position = anchorPoint.position;
                doOnce = false;
            }
            rig.position = anchorPoint.position;
            anchorPoint.rotation = anchorPoint.rotation * rotationChange;
            if (HasRotated()) {
                if (inertiaTimer < 1) {
                    inertiaTimer += Time.deltaTime * inertiaTimerMultiplier;
                }
                if (inertiaTimer >= 1) {
                    inertiaTimer = 1;
                }
                bodyRig.position += (attachPoint.position - bodyRig.transform.position) * inertiaTimer * inertiaMultiplier;
                return;
            }
        }
    }

    bool HasRotated() {
        if (Vector3.Distance(attachPoint.position, bodyRig.transform.position) > rotationDeadzone) {
            return true;
        } else return false;
    }
}
