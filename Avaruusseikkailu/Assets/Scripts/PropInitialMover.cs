using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropInitialMover : MonoBehaviour
{
    public ForceMode forceMode;
    public Vector3 direction;
    public Vector3 rotation;
    public float speed;
    Rigidbody rig;
    public bool randomizedDirection;
    public bool randomizedRotation;
    public Vector3 randomizedDirectionMax;
    public Vector3 randomizedRotationMax;
    public float randomizedSpeedMax;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        if (randomizedRotation) {
            float rx = Random.Range(-randomizedRotationMax.x, randomizedRotationMax.x);
            float ry = Random.Range(-randomizedRotationMax.y, randomizedRotationMax.y);
            float rz = Random.Range(-randomizedRotationMax.z, randomizedRotationMax.z);
            rig.angularVelocity = new Vector3(rx, ry, rz);
        } else rig.angularVelocity = rotation;
        if (randomizedDirection) {
            float dx = Random.Range(-randomizedDirectionMax.x, randomizedDirectionMax.x);
            float dy = Random.Range(-randomizedDirectionMax.y, randomizedDirectionMax.y);
            float dz = Random.Range(-randomizedDirectionMax.z, randomizedDirectionMax.z);
            float rspeed = Random.Range(0, randomizedSpeedMax);
            rig.AddForce(new Vector3(dx, dy, dz) * rspeed, forceMode);
        } else rig.AddForce(direction * speed, forceMode);
    }

}
