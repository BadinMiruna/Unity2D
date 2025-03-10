using UnityEngine;

public class SPlayer : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    private float dashTime;

    [SerializeField] private float dashCoolDown;
    private float dashCoolDownTimer;

    private float xInput;

    private int facingDirection = 1;
    private bool facingRight = true;

    [Header("Colission Info")]

    [SerializeField] private float groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        Movement();
        CheckInput();
        ColissionCheck();

        dashTime -= Time.deltaTime;
        dashCoolDownTimer -= Time.deltaTime;




        flipControler();
        AnimatorControl();
    }

    private void ColissionCheck()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheck, whatIsGround);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void DashAbility()
    {
        if (dashCoolDownTimer < 0)
        {
            dashCoolDownTimer = dashCoolDown;
            dashTime = dashDuration;
        }
    }
    private void Movement()
    {
        if (dashTime > 0)
        {
            rb.velocity = new Vector2(xInput * dashSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }

    }

    private void Jump()
    {
        if (isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void AnimatorControl()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetFloat("Velocity", rb.velocity.y);
        anim.SetBool("IsMoving", isMoving);
        anim.SetBool("IsGround", isGround);
        anim.SetBool("Dash", dashTime > 0);
    }

    private void flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

    }

    private void flipControler()
    {
        if (rb.velocity.x > 0 && !facingRight)
            flip();
        else if (rb.velocity.x < 0 && facingRight)
            flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheck));

    }
}
