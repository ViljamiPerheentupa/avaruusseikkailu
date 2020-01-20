using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTester : MonoBehaviour
{
    public Transform[] positions;
    public float speed = 1;
    Vector3 inputPos;
    Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        inputPos = positions[0].position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            rig.position = positions[0].position;
            inputPos = positions[0].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            rig.position = positions[1].position;
            inputPos = positions[1].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            rig.position = positions[2].position;
            inputPos = positions[2].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            rig.position = positions[3].position;
            inputPos = positions[3].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            rig.position = positions[4].position;
            inputPos = positions[4].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            rig.position = positions[5].position;
            inputPos = positions[5].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            rig.position = positions[6].position;
            inputPos = positions[6].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            rig.position = positions[7].position;
            inputPos = positions[7].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            rig.position = positions[8].position;
            inputPos = positions[8].position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            rig.position = positions[9].position;
            inputPos = positions[9].position;
        }
        if (Input.GetKey(KeyCode.Space)) {
            rig.position += transform.forward * speed * Time.deltaTime;
        } else rig.position = inputPos;
    }
}
