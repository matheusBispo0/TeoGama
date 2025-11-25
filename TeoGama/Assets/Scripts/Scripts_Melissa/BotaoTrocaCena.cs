using UnityEngine;
using UnityEngine.SceneManagement;
public class BotaoTrocaCena : MonoBehaviour
{
    public void TrocarCena()
    {
        SceneManager.LoadScene("Iniciar (Melissa)");
        Time.timeScale = 1.0f;
    }

    public void MudaDECena()
    {
        SceneManager.LoadScene("Entrada");
        Time.timeScale = 1.0f;
    }
}