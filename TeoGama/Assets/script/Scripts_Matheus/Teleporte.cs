using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporte : MonoBehaviour
{
    public GameObject interactUI;
    public string nomeDaCena; // Nome da cena que deseja carregar
    private bool jogadorPerto = false;


    void Start ()
    {
        interactUI.SetActive(false);
    }
    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            interactUI.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            interactUI.SetActive(false);
            
        }
    }
}