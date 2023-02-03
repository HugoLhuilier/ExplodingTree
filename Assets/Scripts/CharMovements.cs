using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPow;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float velPower;
    [SerializeField] private float wallFriction;
    [SerializeField] private Vector2 wallJumpPow;
    [SerializeField] private float jumpTimeMax;
    [SerializeField] private float wallJumpTime;
    [SerializeField] private float maxFallSpeed;
    [SerializeField] private float sustainJumpPow;
    [SerializeField] private float dashSpeed;

    private Rigidbody2D body;
    private BoxCollider2D bCollider;
    private Transform trans;

    private float horizontalAxis;
    private float verticalAxis;
    private float facing;
    private bool isFalling;
    private bool onWall;
    private bool isGrounded;
    private float wallJumpCooldown = 0;
    private bool canMove = true;
    private bool isJumping;
    private float jumpCooldown = 0;
    private bool spacePressed = false;
    private bool dashPressed = false;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        bCollider = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        setBool();
        setCooldowns();
    }

    private void FixedUpdate()
    {
        if (horizontalAxis > 0.1f)
        {
            facing = 1;
        }
        if (horizontalAxis < -0.1f)
        {
            facing = -1;
        }

        if (canMove)
        {
            Run();
        }

        if (spacePressed)
        {
            Jump();
            spacePressed = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            sustainJump();
        }

        body.velocity = new Vector2(body.velocity.x, Mathf.Max(body.velocity.y, -maxFallSpeed));
    }

    private void getInput()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        verticalAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
    }

    private void setBool()
    {
        isGrounded = Physics2D.BoxCast(bCollider.bounds.center, bCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer).collider != null;
        onWall = Physics2D.BoxCast(bCollider.bounds.center, bCollider.bounds.size, 0, new Vector2(facing, 0), 0.1f, wallLayer).collider != null;
        isFalling = body.velocity.y < 0;
        canMove = wallJumpCooldown >= 0;
        if (isGrounded || jumpCooldown > 0 || Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void Run()
    {
        float targetSpeed = horizontalAxis * speed;
        float speedDif = targetSpeed - body.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.1f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        body.AddForce(movement * Vector2.right);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            jumpCooldown = -jumpTimeMax;
            body.AddForce(jumpPow * Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void sustainJump()
    {
        if (isJumping)
        {
            body.AddForce(new Vector2(0, - sustainJumpPow * jumpCooldown / jumpTimeMax ));
        }
    }

    private void setCooldowns()
    {
        jumpCooldown += Time.deltaTime;
    }
}
