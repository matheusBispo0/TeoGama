using UnityEngine;

public class Animation : MonoBehaviour
{
    // Variável de campo para armazenar o input horizontal, acessível em Update e Flip.
    private float moveHorizontal; 
    
    private SpriteRenderer spriteRenderer;
    public Animator anim;

    private bool wasWalking = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (anim == null)
            anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 1. CORREÇÃO: Atribui o valor atualizado à variável de campo
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical"); // Esta continua local

        // Chama Flip APÓS atualizar moveHorizontal
        Flip();
        
        // Verifica se houve movimento horizontal ou vertical
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            wasWalking = true;
        }
        else
        {
            wasWalking = false;
        }

        // Atualiza o parâmetro do Animator
        anim.SetBool("isWalking", wasWalking);
    }

    void Flip()
    {
        // Usa o valor ATUALIZADO da variável de campo moveHorizontal
        if (moveHorizontal > 0)
        {
            // Não invertido (olhando para a direita)
            spriteRenderer.flipX = false; 
        }
        else if (moveHorizontal < 0)
        {
            // Invertido (olhando para a esquerda)
            spriteRenderer.flipX = true; 
        }
    }
}