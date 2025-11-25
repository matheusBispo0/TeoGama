using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isGrounded;

    [SerializeField]
    public Transform groundCheck;
    [SerializeField]
    private float checkRadius = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;

    // Adicione esta nova variável
    private bool canJump;

    public bool canMove { get; internal set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Verifique se o jogador pode pular
        if (isGrounded)
        {
            canJump = true;
        }

        // Condição para pular: botão pressionado E pode pular
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            // Defina a flag como false imediatamente após o pulo
            canJump = false;
        }
    }
}