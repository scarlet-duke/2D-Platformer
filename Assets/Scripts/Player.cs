using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private Game _game;

    private bool isGrounded;
    private Rigidbody2D rb;
    private float moveInput;
    private bool isFacingRight = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * _moveSpeed, rb.velocity.y);

        if (moveInput < 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput > 0 && isFacingRight)
        {
            Flip();
        }

        if(moveInput == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Death()
    {
        _game.GameOver();
    }
}
