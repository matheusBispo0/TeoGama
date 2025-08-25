using UnityEngine; 

[RequireComponent(typeof(Rigidbody2D))] 

public class PlayerMovement : MonoBehaviour 
{ 

    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    public Rigidbody2D rb; 
    public Vector2 moveInput; 

    public void Awake() 
    {
        rb = GetComponent<Rigidbody2D>(); 
    } 

  

    public void Update() 
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        moveInput = new Vector2(moveX, 0f).normalized; 

        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            rb.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        } 

    } 

    public void FixedUpdate() 
    { 
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    } 

} 