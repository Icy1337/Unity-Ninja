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

        float horizontal = (Input.GetAxis("Horizontal") + leftJoystick.Horizontal);
        float vertical = (Input.GetAxis("Vertical") + leftJoystick.Vertical);

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

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
        float horizontal = (Input.mousePosition.x + rightJoystick.Horizontal);
        float vertical = (Input.mousePosition.x + rightJoystick.Vertical) * -1;

        Vector3 targetPosition = new Vector3(horizontal, 0, vertical);

        Quaternion rotation = Quaternion.LookRotation(targetPosition);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 60 * Time.deltaTime);
    }
}
