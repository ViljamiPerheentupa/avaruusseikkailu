using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform objectToMove;
    public Transform attachPoint;
    Rigidbody rig;
    Rigidbody objRig;
    public float rotationSpeed = 10f;
    float inertiaTimer = 0;
    Vector3 lastInertia;
    Quaternion lastRotation;
    Quaternion rotationChange;
    float handDistance;
    bool letGo = false;
    bool doOnce = true;
    public float speedMultiplier = 0.5f;
    public float inertiaMultiplier = 0.2f;
    public float inertiaTimerMultiplier = 0.33f;
    public float rotationDeadzone = 1f;
    public float rotationMultiplier = 0.5f;

    void Start()
    {
        handDistance = Vector3.Distance(transform.position, objectToMove.position);
        lastRotation = transform.localRotation;
        attachPoint.position = objectToMove.position;
        rig = GetComponent<Rigidbody>();
        objRig = objectToMove.GetComponent<Rigidbody>();
    }

    private void Update() {
        float rotationx = Input.GetAxis("Horizontal");
        float rotationy = Input.GetAxis("Vertical");
        rig.rotation *=  Quaternion.Euler(0, rotationx * rotationSpeed, -rotationy * rotationSpeed);
        if (Input.GetKeyDown(KeyCode.F)) {
            if (!letGo) {
                letGo = true;
            } else {
                letGo = false;
                doOnce = true;
            }
        }
        if (letGo && doOnce) {
            //objRig.AddForce(lastInertia * speedMultiplier, ForceMode.VelocityChange);
            doOnce = false;
        }
    }

    void FixedUpdate()
    {
        rotationChange = Quaternion.Inverse(lastRotation) * transform.localRotation;
        lastRotation = transform.localRotation;
        //print(inertiaChange.x + ", " + inertiaChange.y + ", " + inertiaChange.z);
        if (HasMoved() && !letGo) {
            if (inertiaTimer < 1) {
                inertiaTimer += Time.fixedDeltaTime * inertiaTimerMultiplier;
            }
            if (inertiaTimer >= 1) {
                inertiaTimer = 1;
            }
            //objRig.position += (attachPoint.position - objectToMove.position) * inertiaTimer * inertiaMultiplier;
            objRig.position = Vector3.Slerp(objRig.position, attachPoint.position, inertiaTimer * inertiaMultiplier);
        }
        if (Vector3.Distance(attachPoint.position, objectToMove.position) < rotationDeadzone) {
            if (inertiaTimer > 0) {
                inertiaTimer -= Time.fixedDeltaTime;
            }
            if (inertiaTimer <= 0) {
                inertiaTimer = 0;
            }
        }
    }


    bool HasMoved() {
        if (attachPoint.position == objectToMove.position) {
            inertiaTimer = 0;
            return false;
        } else return true;
    }
}
