using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAnchor : MonoBehaviour {
    public Transform tracked;
    Vector3 last;
    Vector3 change;
    public float maxValue = 1;

    private void Start() {
        last = tracked.position;
    }

    void Update() {
        change = last - tracked.position;
        last = tracked.position;
        float trackY = change.y;
        trackY = Mathf.Clamp(trackY, -maxValue, maxValue);
        transform.position = transform.position - new Vector3(0, trackY, 0);
    }
}
