using UnityEngine;

using UnityEngine.SceneManagement;

public class ReiniciarFase : MonoBehaviour
{
    public void VoltarFase()
    {
        SceneManager.LoadScene("Gustavo");
        Time.timeScale = 1.0f;
    }

}

