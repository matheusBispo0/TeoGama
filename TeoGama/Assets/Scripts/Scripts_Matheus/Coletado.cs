using UnityEngine;


public class Coletado : MonoBehaviour
{
    public GameObject chaveVisualPrefab;  // chave que aparece sobre o jogador
    public Quadro quadro;                 // referência ao script do quadro

    private bool jogadorPerto = false;
    private Transform jogadorTransform;

    void Update()
    {
        // Só tenta coletar se o jogador apertar E perto da chave
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            // Verifica se o quadro já caiu
            if (quadro != null && quadro.Caiu)
            {
                ColetarChave();
            }
            else
            {
                Debug.Log("Você ainda não pode pegar a chave — o quadro não caiu!");
            }
        }
    }

    void ColetarChave()
    {
        if (jogadorTransform == null) return;

        // Cria a chave sobre o jogador
        GameObject chave = Instantiate(
            chaveVisualPrefab,
            jogadorTransform.position + new Vector3(0, 1f, 0),
            Quaternion.identity
        );

        chave.transform.SetParent(jogadorTransform);
        chave.name = "chave";

        Destroy(gameObject); // destrói a chave da cena
        Debug.Log("Chave coletada!");
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