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
        // Come�a invis�vel
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
        // Seguran�a extra: se j� apareceu, nunca mais some
        if (jaApareceu && !spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
        }
    }
}