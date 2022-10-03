using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    [SerializeField] float minY, maxY;

    Vector2 lastPosition;

    [SerializeField] Transform Ground, midGround;

    private void Start()
    {
        lastPosition = transform.position;
    }
    private void Update()
    {
        limitCamera();
        moveGrounds();
    }

    void limitCamera()
    {
        transform.position = new Vector3(targetTransform.position.x,
        Mathf.Clamp(targetTransform.position.y, minY, maxY),
        transform.position.z);
    }

    void moveGrounds()
    {
        Vector2 diff = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y);

        Ground.position += new Vector3(diff.x, diff.y, 0f);
        midGround.position += new Vector3(diff.x, diff.y, 0f) * .5f;

        lastPosition = transform.position;
    }

}
