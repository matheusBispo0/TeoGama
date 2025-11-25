using UnityEngine;

public class Coletado: MonoBehaviour
{ 
    private bool jogadorPerto = false;
    private Transform jogadorTransform;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Chave coletada!");
            // Torna filha do player para referência na porta
            transform.SetParent(jogadorTransform);
            transform.localPosition = new Vector3(0, 2f, 0);
            transform.localScale = Vector3.one; // mantém escala
            // A partir daqui a chave está "no player" e pode ser usada na porta
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            jogadorTransform = other.transform;
            Debug.Log("Player perto da chave. Pressione E para pegar.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            jogadorTransform = null;
        }
    }
}