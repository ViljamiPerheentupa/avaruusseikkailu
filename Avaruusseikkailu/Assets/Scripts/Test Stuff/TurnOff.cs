using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public KeyCode key;
    public bool isOn = true;
    Light light;

    private void Start() {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (isOn) {
            light.enabled = true;
            if (Input.GetKeyDown(key)) {
                isOn = false;
                light.enabled = false;
                return;
            }
        }
        if (!isOn) {
            if (Input.GetKeyDown(key)) {
                isOn = true;
                return;
            }
        }
    }

    
}
