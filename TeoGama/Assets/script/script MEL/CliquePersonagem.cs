using UnityEngine;
public class CliquePersonagem : MonoBehaviour
{
    public string Inimigo { get; private set; }

    void OnMouseDown()
    {
        Debug.Log("Clicou em: " + Inimigo);

    }
}