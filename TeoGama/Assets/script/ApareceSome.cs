using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float intervalo = 2f;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        InvokeRepeating("Alternar", intervalo, intervalo);
    }
    void Alternar()
    {
        bool novoEstado = !spriteRenderer.enabled;
        spriteRenderer.enabled = novoEstado;
        col.enabled = novoEstado;
    }
    void OnMouseDown()
    {
        if (spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            col.enabled = false;
            GameManager.instancia.AdicionarPonto();
        }
    }
}