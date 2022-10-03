using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzelFonksiyonlar : MonoBehaviour
{
    public float speed = 5f;
    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

}
