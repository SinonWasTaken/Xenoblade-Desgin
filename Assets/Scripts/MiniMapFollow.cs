using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 positionOffset;

    private Vector3 refVelocity;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + positionOffset, ref refVelocity, 0);
    }
}
