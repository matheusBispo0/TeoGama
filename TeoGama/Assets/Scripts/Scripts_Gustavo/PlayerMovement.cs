using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;

    private bool isGrounded;

    private float coyoteTime = 0.12f;
    private float coyoteCounter;

    private float jumpBufferTime = 0.12f;
    private float jumpBufferCounter;

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 🔵 TESTE 1 — Detectar o apertar do espaço
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("APERTOU SPACE!");
            jumpBufferCounter = jumpBufferTime;
        }
        else
            jumpBufferCounter -= Time.deltaTime;

        // Verifica chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // 🔵 TESTE 2 — Mostrar se está no chão
        if (isGrounded)
            Debug.Log("NO CHÃO");

        // Coyote time
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        // 🔵 TESTE 3 — Verificar condição do pulo
        if (jumpBufferCounter > 0 && coyoteCounter > 0)
        {
            Debug.Log("CONDICAO DE PULO ATIVA!");
            Jump();
            jumpBufferCounter = 0;
            coyoteCounter = 0;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        Debug.Log("PULOU!!!");

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
