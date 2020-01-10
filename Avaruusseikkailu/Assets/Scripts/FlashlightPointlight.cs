using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPointlight : MonoBehaviour
{
    public Light lightSource;
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
            Collider hitObject = hit.collider;
            lightSource.transform.position = location - transform.position * (Vector3.Distance(location, transform.position) - 1);
            lightSource.intensity = lightSource.intensity * (maxDistance / Vector3.Distance(location, transform.position));
        }
    }
}
