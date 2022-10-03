using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        transform.Translate(h, 0f, 0f);

        float xPos = Mathf.Clamp(transform.position.x, -10f, 10f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
