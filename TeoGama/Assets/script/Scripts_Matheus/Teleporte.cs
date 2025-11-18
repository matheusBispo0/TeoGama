using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporte : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameObject interactUI;
    public string nomeDaCena; // Nome da cena que deseja carregar
    private bool jogadorPerto = false;


    void Start ()
    {
        interactUI.SetActive(false);
    }
=======
    public string nomeDaCena; // Nome da cena para onde vai teleportar
    private bool jogadorPerto = false;

>>>>>>> Stashed changes
    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }

<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D other)
=======
    void OnTriggerEnter2D(Collider2D other)
>>>>>>> Stashed changes
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
<<<<<<< Updated upstream
            interactUI.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
=======
        }
    }

    void OnTriggerExit2D(Collider2D other)
>>>>>>> Stashed changes
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
<<<<<<< Updated upstream
            interactUI.SetActive(false);
            
        }
    }
}
=======
        }
    }
}
>>>>>>> Stashed changes
