using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorManager : MonoBehaviour
{
    public Transform[] hedefler;
    int gecerliHedef;
    public float moveSpeed;
    private void Update()
    {         
       transform.position = Vector3.MoveTowards(transform.position, hedefler[gecerliHedef].position, moveSpeed * Time.deltaTime); 
       if(Vector3.Distance(transform.position, hedefler[gecerliHedef].position) < 0.1f)
        {
            gecerliHedef++;
            if (gecerliHedef >= hedefler.Length)
            {
                gecerliHedef = 0;
            }             
        }
    }
}
