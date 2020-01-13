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
    void Start()
    {
        attachPoint.position = objectToMove.position;
        rig = GetComponent<Rigidbody>();
        objRig = objectToMove.GetComponent<Rigidbody>();
    }

    private void Update() {
        float rotationx = Input.GetAxis("Horizontal");
        float rotationy = Input.GetAxis("Vertical");
        rig.rotation *=  Quaternion.Euler(0, rotationx * rotationSpeed, -rotationy * rotationSpeed);
    }

    void FixedUpdate()
    {
        if (HasMoved()) {
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
