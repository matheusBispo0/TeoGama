using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;
    public BarraDeVida barraDeVida;

    void Start()
    {
        vidaAtual = vidaMaxima;
        if (barraDeVida != null)
        {
            barraDeVida.SetMaxVida(vidaMaxima);
        }
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log(gameObject.name + " tomou " + dano + " de dano!");

        if (barraDeVida != null)
        {
            barraDeVida.SetVida(vidaAtual);
        }

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu!");
        Destroy(gameObject);
    }
}
