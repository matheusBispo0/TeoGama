using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int dano = 10;

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            colisao.gameObject.GetComponent<Vida>().TomarDano(dano);
        }
    }
}