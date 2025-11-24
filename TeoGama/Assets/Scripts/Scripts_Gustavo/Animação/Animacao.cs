using UnityEngine;


[RequireComponent(typeof(Animator))]

public class Animacao : MonoBehaviour
{
    [Tooltip("SpriteRenderer para flip (opcional).")]
    public SpriteRenderer spriteRenderer;

    [Header("Nomes dos parâmetros do Animator")]
    public string animStateParam = "AnimState";
    public string attackTrigger = "Attack";

    Animator m_animator;
    bool facingRight = true;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Liga/desliga o estado de correr (true = Run/2, false = Idle/0)
    public void SetRunning(bool running)
    {
        m_animator.SetInteger(animStateParam, running ? 2 : 0);
    }

    // Alternativa: define por velocidade (velocidade horizontal)
    public void SetSpeed(float horizontalSpeed)
    {
        SetRunning(Mathf.Abs(horizontalSpeed) > Mathf.Epsilon);
    }

    // Dispara animação de ataque
    public void TriggerAttack()
    {
        m_animator.SetTrigger(attackTrigger);
    }

    // Faz o personagem olhar para a direção X (use dx = target.x - transform.x)
    public void FaceDirection(float dirX)
    {
        if (dirX > 0f && !facingRight) Flip();
        else if (dirX < 0f && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        if (spriteRenderer != null)
            spriteRenderer.flipX = !spriteRenderer.flipX;
        else
        {
            Vector2 s = transform.localScale;
            s.x *= -1f;
            transform.localScale = s;
        }
    }
}