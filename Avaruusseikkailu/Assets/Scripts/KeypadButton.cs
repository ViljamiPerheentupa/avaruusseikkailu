using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public int input;
    public bool canBePushed = true;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && canBePushed) {
            GetComponentInParent<IKeypad>().AddKey(input);
        }
    }
}
