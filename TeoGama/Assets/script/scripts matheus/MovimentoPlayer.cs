using UnityEngine;

public class MovimentoPlayer : MonoBehaviour

{

    public float moveSpeed = 5f;

    public float jumpForce = 7f;

    private Rigidbody2D rb;

    private bool isGrounded;

    [SerializeField] public Transform groundCheck;

    [SerializeField] private float checkRadius = 0.2f;

    [SerializeField] private LayerMask groundLayer;

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()

    {

        float moveInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);


        if (Input.GetButtonDown("Jump") && isGrounded)

        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }

    }

}
