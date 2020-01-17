using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderToHeadLevel : MonoBehaviour
{
    Transform obj;
    CapsuleCollider body;
    bool doOnce = true;
    public FollowBody followBody;

    void LateUpdate()
    {
        if (doOnce) {
            obj = Camera.main.transform;
            body = GetComponent<CapsuleCollider>();
            float colliderY = body.bounds.size.y / 2;
            float colliderX = body.bounds.size.x / 2;
            float colliderZ = body.bounds.size.z / 2;
            body.center = new Vector3(0, obj.position.y - colliderY, 0);
            doOnce = false;
        }
        this.enabled = false;
    }
}
