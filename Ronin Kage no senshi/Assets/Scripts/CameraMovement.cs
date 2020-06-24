using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject followTarget;
    private Vector3 _cameraOffset;
    public float moveSpeed;
    public bool rotateAroundPlayer;
    public float rotationSpeed = 10.0f;

    void Start()
    {
        _cameraOffset = transform.position - followTarget.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {

            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
                _cameraOffset = camTurnAngle * _cameraOffset;
            }

            Vector3 newPos = followTarget.transform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * moveSpeed);

            if (rotateAroundPlayer)
            {
                transform.LookAt(followTarget.transform);
            }
        }
    }
}
