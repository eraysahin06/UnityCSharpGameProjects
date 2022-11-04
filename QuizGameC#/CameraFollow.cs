using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 targetDistance;

    private void Start()
    {
        targetDistance = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + targetDistance, .1f);
        }    
    }
}
