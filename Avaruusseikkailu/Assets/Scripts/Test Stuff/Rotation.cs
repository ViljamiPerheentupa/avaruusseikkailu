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
    Vector3 inertiaChange;
    bool letGo = false;
    bool doOnce = true;
    public float speedMultiplier = 0.5f;
    void Start()
    {
        lastInertia = objectToMove.position;
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
            objRig.AddForce(lastInertia * speedMultiplier, ForceMode.VelocityChange);
            doOnce = false;
        }
    }

    void FixedUpdate()
    {
        inertiaChange = objectToMove.position - lastInertia;
        lastInertia = objectToMove.position;
        print(inertiaChange.x + ", " + inertiaChange.y + ", " + inertiaChange.z);
        if (HasMoved() && !letGo) {
            if (inertiaTimer < 1) {
                inertiaTimer += Time.fixedDeltaTime / 2;
            }
            if (inertiaTimer >= 1) {
                inertiaTimer = 1;
            }
            objRig.position += (attachPoint.position - objectToMove.position) * inertiaTimer / 2;
        }
    }


    bool HasMoved() {
        if (attachPoint.position == objectToMove.position) {
            inertiaTimer = 0;
            return false;
        } else return true;
    }
}
