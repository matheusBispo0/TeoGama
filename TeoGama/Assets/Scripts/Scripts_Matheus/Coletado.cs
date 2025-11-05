using UnityEngine;


public class Coletado : MonoBehaviour
{
    public GameObject chaveVisualPrefab;
     //aparece sobre o jogador
    private bool jogadorPerto = false;
    private Transform jogadorTransform;

 void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            ColetarChave();
        }
    }

    void ColetarChave()
    {
        if (jogadorTransform == null) return;

        // Cria a chave sobre o jogador
        GameObject chave = Instantiate(chaveVisualPrefab, jogadorTransform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        chave.transform.SetParent(jogadorTransform); 
        // chave fica presa 
        chave.name = "chave";
         

        Destroy(gameObject); // destroi a chave 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            jogadorTransform = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            jogadorTransform = null;
        }
    }
}
