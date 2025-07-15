using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float moveInput;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0f));
    }
}