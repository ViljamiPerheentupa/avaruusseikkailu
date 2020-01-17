using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XAnchor : MonoBehaviour
{
    public Transform tracked;
    Vector3 last;
    Vector3 change;
    public float maxValue = 1;

    private void Start() {
        last = tracked.position;
    }

    void Update()
    {
        change = last - tracked.position;
        last = tracked.position;
        float trackX = change.x;
        trackX = Mathf.Clamp(trackX, -maxValue, maxValue);
        transform.position = transform.position - new Vector3(trackX, 0, 0);
    }
}
