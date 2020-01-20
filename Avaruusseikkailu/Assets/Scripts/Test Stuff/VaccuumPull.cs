using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccuumPull : MonoBehaviour
{
    public Transform pullPoint;
    public float speed;
    public ForceMode forceMode;
    public LayerMask mask;
    BoxCollider col;
    Vector3 size;
    public bool testing;
    void Start()
    {
        col = GetComponent<BoxCollider>();
        size = col.bounds.size;
    }

    void Update()
    {
        if (testing) {
            if (Input.GetKeyDown(KeyCode.F5)) {
                Pull();
            }
        }
    }

    public void Pull() {
        Collider[] objects = Physics.OverlapBox(transform.position, size / 2, transform.rotation, mask);
        foreach (Collider obj in objects) {
            if (obj.GetComponent<Rigidbody>() != null) {
                obj.GetComponent<Rigidbody>().AddForce((pullPoint.position - obj.transform.position) * speed, forceMode);
            }
        }
    }
}
