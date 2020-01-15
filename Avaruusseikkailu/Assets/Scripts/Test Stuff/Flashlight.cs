using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    bool state = true;
    public GameObject flashlight;
    bool cooldown = false;
    float timer;

    void Update()
    {
        if (cooldown) {
            timer += Time.deltaTime;
            if (timer >= 0.5f) {
                cooldown = false;
            }
        }
        if (state) {
            flashlight.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && !cooldown) {
                state = false;
                cooldown = true;
            }
        }
        if (!state) {
            flashlight.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F) && !cooldown) {
                state = true;
                cooldown = true;
            }
        }
    }
}
