using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPointlight : MonoBehaviour
{
    public GameObject lightSource;
    RaycastHit hit;
    public LayerMask hitLayers;
    public float maxDistance = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, hitLayers)) {
            Vector3 location = hit.point;
            lightSource.transform.position = location;
        }
    }
}
