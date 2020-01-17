using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class HandAnchor : MonoBehaviour
{
    public LayerMask mask;
    public float moveSpeed;
    Rigidbody rig;
    GameObject player;
    float rayLength = 0.5f;
    public GrabbableSensor RightHand;
    public GrabbableSensor LeftHand;
    public SteamVR_Action_Boolean ToggeGripButton;
    public ConfigurableJoint GrabJoint;
    public List<GrabbableSensor> grabbedHands = new List<GrabbableSensor>();

    private void Awake() {
        rig = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    bool IsGrabbing() {
        return grabbedHands.Count > 0;
    }

    GrabbableSensor ActiveHand() {
        return grabbedHands[0];
    }

    void Update()
    {
        if (IsGrabbing()) {
            GrabJoint.targetPosition = -ActiveHand().transform.localPosition;
        }
    }

    private void FixedUpdate() {
        var targetPos = Vector3.up * transform.position.y;
        rig.MovePosition(Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime));
    }

    void UpdateHand(GrabbableSensor hand) {
        if (grabbedHands.Contains(hand)) {
            if (ToggeGripButton.GetStateUp(hand.hand)) {
                grabbedHands.Remove(hand);
                if (!IsGrabbing()) {
                    GrabJoint.connectedBody = null;
                }
            }
        } else {
            if (hand.touchedCount > 0 && ToggeGripButton.GetStateDown(hand.hand)) {
                grabbedHands.Insert(0, hand);
                print("adding hand " + hand.name + " to list idx 0");
                GrabJoint.transform.position = hand.transform.position;
                GrabJoint.connectedBody = GetComponent<Rigidbody>();
            }
        }
    }
}
