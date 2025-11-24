using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Porta : MonoBehaviour
{
    public string nomeCenaDestino = "Gustavo"; // nome da cena para onde vai
    public float tempoAntesDeTrocar = 1f;    // tempo da animação/espera
    public Animator animator;                // opcional, se tiver animação
    public string parametroAbrir = "Abrir";  // nome do parâmetro no Animator

    private bool jogadorPerto = false;
    private Transform jogadorTransform;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            // verifica se o jogador tem a chave
            Transform chave = jogadorTransform.Find("chave");
            if (chave != null)
            {
                StartCoroutine(AbrirPorta());
            }
            else
            {
                Debug.Log("Você precisa da chave para abrir esta porta!");
            }
        }
    }

    IEnumerator AbrirPorta()
    {
        Debug.Log("Abrindo porta...");

        // se tiver animação
        if (animator != null)
        {
            animator.SetBool(parametroAbrir, true);
        }

        // destrói a chave (consome ao usar)
        Transform chave = jogadorTransform.Find("chave");
        if (chave != null)
            Destroy(chave.gameObject);

        // espera tempo configurado
        yield return new WaitForSeconds(tempoAntesDeTrocar);

        // muda de cena
        SceneManager.LoadScene(nomeCenaDestino);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            jogadorTransform = other.transform;
            Debug.Log("Pressione E para abrir a porta.");
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
