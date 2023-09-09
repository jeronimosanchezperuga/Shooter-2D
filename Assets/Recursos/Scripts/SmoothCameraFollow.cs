using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform limitBottomLeft;
    public Vector3 offset;
    public float damping;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }
    void FixedUpdate()
    {
        Vector3 movePosition;
        if (limitBottomLeft)
        {
            float minX = Mathf.Clamp(target.position.x, limitBottomLeft.position.x, Mathf.Infinity) ;
            float minY = Mathf.Clamp(target.position.y, limitBottomLeft.position.y, Mathf.Infinity) ;
            movePosition = new Vector3(minX, minY,0) + offset;
        }
        else
        {
            movePosition = target.transform.position + offset;
        }
        transform.position = Vector3.SmoothDamp(transform.position,movePosition, ref velocity, damping);
    }
}
