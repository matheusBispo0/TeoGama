using UnityEngine;
using UnityEngine.UI;
public class Lanterna : MonoBehaviour
{
    public float distanciaMaxima = 10f;
    public LayerMask camadaInimigo;
    public Text contadorTexto;
    private int contador = 0;
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distanciaMaxima, camadaInimigo);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
            contador++;
            AtualizarHUD();
        }
    }
    void AtualizarHUD()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = "Encontrados: " + contador;
        }
    }
}
