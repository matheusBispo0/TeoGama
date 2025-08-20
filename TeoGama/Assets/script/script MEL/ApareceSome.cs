using UnityEngine;
public class ApareceSome : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private int contador = 0;
    private bool jaApareceu = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        // Começa invisível
        spriteRenderer.enabled = false;
    }
    void OnMouseEnter()
    {
        if (!jaApareceu)
        {
            // Faz aparecer
            spriteRenderer.enabled = true;
            contador++;
            jaApareceu = true;
            Debug.Log("Personagem apareceu! Contagem: " + contador);
        }
    }
    void Update()
    {
        // Segurança extra: se já apareceu, nunca mais some
        if (jaApareceu && !spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
        }
    }
}