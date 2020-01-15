using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightLag : MonoBehaviour
{
    Vector3 vectOffset;
    GameObject goFollow;
    [SerializeField] float speed = 3.0f;

    private void Start() {
        goFollow = Camera.main.gameObject;
        vectOffset = transform.position - goFollow.transform.position;
    }

    private void Update() {
        transform.position = goFollow.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
    }
}
