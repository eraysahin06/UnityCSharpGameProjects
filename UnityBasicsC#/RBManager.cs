using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBManager : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = rb.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            mr.sharedMaterial.color = Color.green;
            rb.useGravity = false;
        }
        else
        {
            mr.sharedMaterial.color = Color.red;
            rb.useGravity = true;
        }
    }
}
