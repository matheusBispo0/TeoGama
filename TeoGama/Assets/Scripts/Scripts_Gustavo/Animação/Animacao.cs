using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animacao : MonoBehaviour
{
    [Tooltip("SpriteRenderer para flip (opcional). Se nulo, inverte scale X.")]
    public SpriteRenderer spriteRenderer;

    [Header("Animator parameters (nomes devem existir no Animator)")]
    public string speedParam = "Speed";
    public string attackParam = "Attack";

    Animator animator;
    bool facingRight = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    
    public void SetSpeed(float speed)
    {
        animator.SetFloat(speedParam, Mathf.Abs(speed));
    }

  
    public void TriggerAttack()
    {
        animator.SetTrigger(attackParam);
    }

    public void PlayIdle()
    {
        animator.SetFloat(speedParam, 0f);
    }

    public void FaceDirection(float dirX)
    {
        if (dirX > 0 && !facingRight) Flip();
        else if (dirX < 0 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        if (spriteRenderer != null)
            spriteRenderer.flipX = !spriteRenderer.flipX;
        else
        {
            var s = transform.localScale;
            s.x *= -1;
            transform.localScale = s;
        }
    }
}