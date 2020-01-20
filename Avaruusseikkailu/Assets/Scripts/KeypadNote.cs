using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadNote : MonoBehaviour
{
    public Text renderText;
    public Keypad keypad;
    int pass1;
    int pass2;
    int pass3;
    int pass4;
    bool doOnce = true;

    // Update is called once per frame
    void LateUpdate()
    {
        if (doOnce) {
            pass1 = keypad.pass1;
            pass2 = keypad.pass2;
            pass3 = keypad.pass3;
            pass4 = keypad.pass4;
            renderText.text = pass1 + "" + pass2 + "" + pass3 + "" + pass4;
            doOnce = false;
            this.enabled = false;
        }
    }
}
