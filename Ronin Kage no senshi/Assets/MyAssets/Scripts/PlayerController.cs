using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private CharacterController characterController;
    public LayerMask layerMask;
    private Vector3 currentLookTarget = Vector3.zero;
    public Joystick leftJoystick;
    public Joystick rightJoystick;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        rotatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        Vector3 moveDirection = new Vector3(leftJoystick.Horizontal, 0, leftJoystick.Vertical);

        moveDirection = transform.TransformDirection(moveDirection);
        characterController.SimpleMove(moveDirection * moveSpeed);

        if (moveDirection != Vector3.zero)
        {
            GetComponentInChildren<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isWalking", false);
        }
    }

    private void rotatePlayer()
    {
        Vector3 targetPosition = new Vector3(rightJoystick.Horizontal, 0, rightJoystick.Vertical);
        Quaternion rotation = Quaternion.LookRotation(targetPosition);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 60 * Time.deltaTime);
    }
}
