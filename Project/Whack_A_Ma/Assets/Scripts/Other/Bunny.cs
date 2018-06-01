using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{

    // Move object left and right. ***
    // Occasionally allow it to jump upon random moments.
    // Set a timer for it.

    [SerializeField]
    private float walkingSpeed = 5.0f;
    [SerializeField]
    private float jumpVelocity = 5.0f;

    private bool dirRight = true;
    private bool ableToJump = false;

    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool grounded;

    private Rigidbody2D rb;

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        BackandForth();
        RandomJump();
    }

    void BackandForth()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (dirRight)
            transform.Translate(Vector2.right * walkingSpeed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * walkingSpeed * Time.deltaTime);

        if (screenPos.x >= Screen.width)
        {
            dirRight = false;
        }

        if (screenPos.x <= 0)
        {
            dirRight = true;
        }
    }

    void RandomJump()
    {
        float gravity = 10.0f;

        if (grounded)
            ableToJump = true;

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpVelocity *  Time.deltaTime, ForceMode2D.Impulse);
            Debug.Log("NeggGER!");
        }
    }
}
