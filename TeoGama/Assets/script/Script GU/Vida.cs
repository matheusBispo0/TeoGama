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
            barraDeVida.SetVida(vidaAtual);
        }
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual < 0) vidaAtual = 0;

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
