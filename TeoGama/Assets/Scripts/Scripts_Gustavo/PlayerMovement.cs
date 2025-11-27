using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer sprite;
   [Header("Movimentação")]
   public float moveSpeed = 5f;
   [Header("Pulo")]
   public float jumpForce = 12f;
   private bool isGrounded;
   private bool canJump;
   [Header("Detecção de Chão")]
   public Transform groundCheck;
   public float checkRadius = 0.2f;
   public LayerMask groundLayer;
   private Rigidbody2D rb;
   // Pode ou não se mover (usado por diálogos, cutscenes etc.)
   public bool canMove = true;
   // Variável da chave
   [HideInInspector]
   public bool hasKey = false;
   // 🔹 ADICIONADO: Animator
   private Animator anim;
   void Start()
   {
       rb = GetComponent<Rigidbody2D>();
       // 🔹 ADICIONADO: pega o Animator automaticamente
       anim = GetComponent<Animator>();
   }
   void Update()
   {
       Move();
       Jump();
       // 🔹 ADICIONADO: Atualiza animação (Idle / Run)
       anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
   }
   void Move()
   {
       if (!canMove)
       {
           // Travar movimento horizontal
           rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
           return;
       }
       float moveInput = Input.GetAxisRaw("Horizontal");
       rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
       // 🔹 ADICIONADO: Virar sprite
       if (moveInput > 0)
           sprite.flipX = false;
       else if (moveInput < 0)
            sprite.flipX = true;
    }
   void Jump()
   {
       if (!canMove)
           return;
       // Detectar chão
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
       if (isGrounded)
           canJump = true;
       // Pular
       if (Input.GetButtonDown("Jump") && canJump)
       {
           rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
           canJump = false;
       }
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
       // Coletar chave
       if (collision.CompareTag("Key"))
       {
           hasKey = true;
           Destroy(collision.gameObject);
       }
   }
}
