using UnityEngine;
public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;

    public void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log(gameObject.name + " tomou " + dano + " de dano!");

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Debug.Log(gameObject.name + " morreu!");
        Destroy(gameObject);
    }
}