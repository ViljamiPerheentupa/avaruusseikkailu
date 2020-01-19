using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityTrigger : MonoBehaviour
{
    public LayerMask mask;
    public bool usingTag;
    public string tag;
    public UnityEvent onTrigger;


    private void OnTriggerEnter(Collider other) {
        if (usingTag) {
            if (other.gameObject.CompareTag(tag)) {
                onTrigger.Invoke();
                print("triggered");
            }
        }
        if (other.gameObject.layer == mask) {
            onTrigger.Invoke();
            print("triggered");
        }
    }
}
