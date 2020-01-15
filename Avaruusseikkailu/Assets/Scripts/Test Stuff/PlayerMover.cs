using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float movementSpeed;
    float normalMoveSpeed;
    float runSpeed;
    Rigidbody rig;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        normalMoveSpeed = movementSpeed;
        runSpeed = movementSpeed * 3;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            movementSpeed = runSpeed;
        } else movementSpeed = normalMoveSpeed;
        float moveX = Input.GetAxis("Horizontal") * movementSpeed;
        float moveZ = Input.GetAxis("Vertical") * movementSpeed;
        //moveX = Mathf.Clamp(moveX, -movementSpeed, movementSpeed);
        //moveZ = Mathf.Clamp(moveZ, -movementSpeed, movementSpeed);
        float altitude = Input.GetAxis("Altitude") * movementSpeed;
        Vector3 movement = new Vector3(moveX, altitude, moveZ);
        movement = transform.TransformDirection(movement);
        rig.velocity = movement;
    }
}
