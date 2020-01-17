using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabbableSensor : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources hand;
    public int touchedCount;
    public bool grabbing;
    bool canGrab = false;
    bool grab;

    private void Update() {
        grab = grabPinch.GetState(hand);
        if (canGrab) {
            if (grab) {
                grabbing = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Grabbable")) {
            canGrab = true;
            print("touching");
            touchedCount++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Grabbable")) {
            canGrab = false;
            touchedCount--;
            if (touchedCount < 0) {
                Debug.LogError("wronk");
            }
        }
    }
}
