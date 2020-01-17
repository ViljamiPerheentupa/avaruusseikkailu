using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AlternativeMovement : MonoBehaviour
{
    public Transform obj;
    public SteamVR_Action_Boolean input;
    public SteamVR_Input_Sources inputSource;
    public Rigidbody bodyRig;
    public float speed = 10;
    float distance;
    public float deadzone;
    public float maxAngularVelocity = 1;
    public float maxAnglesPerSecond = 45f;
    float maxTurn;
    float maxDistance;
    Vector3 targetAngularVelocity;
    Vector3 speedVector;
    public Transform XTracker;
    public Transform YTracker;

    private void Start() {
        bodyRig.maxAngularVelocity = maxAngularVelocity;
        maxTurn = Mathf.Deg2Rad * maxAnglesPerSecond;
        maxDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            maxDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        }
        speedVector = obj.forward * speed;
        print(Vector3.Angle(speedVector, bodyRig.transform.up));
        float angleX = Vector3.Angle(speedVector, bodyRig.transform.forward);
        float angleY = Vector3.Angle(speedVector, bodyRig.transform.up);
        if (input.GetState(inputSource)) {
            bodyRig.AddForce(-obj.forward * speed * Time.deltaTime, ForceMode.Acceleration);
            if (angleX < 90) {

            }
        }

    }
}
