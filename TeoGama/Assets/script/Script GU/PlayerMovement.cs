using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Checagem de chão")]
    public Transform groundCheck;       // Empty object no pé do player
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;       // Camada do chão
    private bool isGrounded;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // Movimento lateral
        float moveX = Input.GetAxisRaw("Horizontal");
        moveInput = new Vector2(moveX, 0f).normalized;

        // Checa se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void FixedUpdate()
    {
        // Movimento horizontal
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnDrawGizmosSelected()
    {
        // Desenha o círculo do groundCheck na cena (só para debug)
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}