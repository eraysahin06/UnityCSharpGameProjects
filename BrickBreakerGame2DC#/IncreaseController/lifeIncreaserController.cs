using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeIncreaserController : MonoBehaviour
{

    public float speed;
    void Update()
    {
        transform.Translate(Vector2.down.normalized * Time.deltaTime * speed);
    }
}
