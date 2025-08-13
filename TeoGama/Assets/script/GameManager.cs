using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int pontos = 0;
    void Awake()
    {
        instancia = this;
    }
    public void AdicionarPonto()
    {
        pontos++;
        Debug.Log("Pontos: " + pontos);
    }
}