using UnityEngine;

public class MovimentoPlayer : MonoBehaviour

{

    public float moveSpeed = 5f;

    public float jumpForce = 7f;

    private Rigidbody2D rb;

    private bool isGrounded = false;
    private bool jogadorPerto = false;

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()

    {

        float move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)

        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.collider.CompareTag("Ground"))

        {

            isGrounded = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)

    {

        if (collision.collider.CompareTag("Ground"))

        {

            isGrounded = false;

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}


