using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpToTransform : MonoBehaviour
{

    public Transform camTarget;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    void FixedUpdate()
    {
        if (camTarget != null)
        {      
            var v3 = camTarget.position;
            var clampX = Mathf.Clamp(v3.x, minX, maxX);
            var clampY = Mathf.Clamp(v3.y, minY, maxY); transform.position = new Vector3(clampX, clampY, -10f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }
}


