using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 desirdPos = target.position + offset;
        Vector3 SmoothPos = Vector3.Lerp(this.transform.position, desirdPos, smoothSpeed);
        this.transform.position = SmoothPos;
        this.transform.LookAt(target);
    }
}
