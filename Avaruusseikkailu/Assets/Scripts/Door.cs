using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openSpeed = 2;
    public float closeSpeed = 0;
    bool isOpening = false;
    public bool isOpened = false;
    bool isClosing = false;
    bool isClosed = false;
    public bool doublesided = false;
    Vector3 sizeLeft;
    Vector3 sizeRight;
    GameObject rightSide;
    GameObject leftSide;
    Vector3 r_closedPos;
    Vector3 r_openPos;
    Vector3 l_closedPos;
    Vector3 l_openPos;
    public bool testing;


    private void Start() {
        if (!isOpened) {
            isClosed = true;
        }
        if (closeSpeed <= 0) {
            closeSpeed = openSpeed;
        }
        if (doublesided) {
            leftSide = transform.Find("DoorLeft").gameObject;
            rightSide = transform.Find("DoorRight").gameObject;
            sizeLeft = transform.Find("DoorLeft").GetComponent<MeshCollider>().bounds.size;
            sizeRight = transform.Find("DoorRight").GetComponent<MeshCollider>().bounds.size;
            r_openPos = rightSide.transform.position + new Vector3(sizeRight.x + 0.1f, 0, 0);
            l_openPos = leftSide.transform.position + new Vector3(-sizeLeft.x - 0.1f, 0, 0);
            r_closedPos = rightSide.transform.position;
            l_closedPos = leftSide.transform.position;
            if (isOpened) {
                leftSide.transform.position = l_openPos;
                rightSide.transform.position = r_openPos;
            }
        }

    }
    void Update()
    {
        if (testing) {
            if (Input.GetKeyDown(KeyCode.O) && isClosed) {
                isOpening = true;
            }
            if (Input.GetKeyDown(KeyCode.P) && isOpened) {
                isClosing = true;
            }
        }
        if (isOpening) {
            OpenDoor();
        }
        if (isClosing) {
            CloseDoor();
        }
        if (Vector3.Distance(leftSide.transform.position, l_openPos) < 0.09f && Vector3.Distance(rightSide.transform.position, r_openPos) < 0.09f) {
            isOpening = false;
            isOpened = true;
        }
        if (Vector3.Distance(leftSide.transform.position, l_closedPos) <= 0 && Vector3.Distance(rightSide.transform.position, r_closedPos) <= 0) {
            isClosing = false;
            isClosed = true;
        }
    }

    public void DoorOpen() {
        isOpening = true;
    }
    void OpenDoor() {
        leftSide.transform.position += (l_openPos - leftSide.transform.position) * Time.deltaTime * openSpeed;
        rightSide.transform.position += (r_openPos - rightSide.transform.position) * Time.deltaTime * openSpeed;
    }

    public void DoorClose() {
        isClosing = true;
    }

    void CloseDoor() {
        leftSide.transform.position = Vector3.MoveTowards(leftSide.transform.position, l_closedPos, Time.deltaTime * closeSpeed);
        rightSide.transform.position = Vector3.MoveTowards(rightSide.transform.position, r_closedPos, Time.deltaTime * closeSpeed);
        //leftSide.transform.position += (l_closedPos - leftSide.transform.position) * Time.deltaTime * closeSpeed;
        //rightSide.transform.position += (r_closedPos - rightSide.transform.position) * Time.deltaTime * closeSpeed;
    }
}
