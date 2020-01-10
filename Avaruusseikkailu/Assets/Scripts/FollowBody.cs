using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBody : MonoBehaviour
{
    public Transform objectToFollow;
    public bool relative = false;
    public bool rotationToo = true;
    Vector3 offset;

    private void Start() {
        offset = transform.position - objectToFollow.position;
    }

    void Update()
    {
        if (relative) {
            transform.position = objectToFollow.position + offset;
        } else
        transform.position = objectToFollow.position;
        if (rotationToo) {
            transform.rotation = objectToFollow.rotation;
        }
    }
}
