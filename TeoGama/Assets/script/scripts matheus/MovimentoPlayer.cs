using UnityEngine;



public class MovimentoPlayer : MonoBehaviour

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



    // Adicione esta nova vari�vel

    private bool canJump;



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



        // Condi��o para pular: bot�o pressionado E pode pular

        if (Input.GetButtonDown("Jump") && canJump)

        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);



            // Defina a flag como false imediatamente ap�s o pulo

            canJump = false;

        }

    }

}