using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class MoveByTouch : MonoBehaviour
{

    public Joystick joystick;

    //public float speed = 14f;
    public float accel = 6f;
    private Vector2 input;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    //private Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = joystick.Horizontal;
        input.y = joystick.Vertical;

        if (input.x > 0f)
        {
            sr.flipX = false;
        }
        else if (input.x < 0f)
        {
            sr.flipX = true;
        }
    }

    void FixedUpdate()
    {
        // 1
        var acceleration = accel;
        var xVelocity = 0f;
        // 2
        if (input.x == 0)
        {
            xVelocity = 0f;
        }
        else
        {
            xVelocity = rb.velocity.x;
        }
        // 3
        rb.AddForce(new Vector2(((input.x * runSpeed) - rb.velocity.x) * acceleration, 0));
        // 4
        rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    }
}
