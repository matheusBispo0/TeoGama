using UnityEngine;
using UnityEngine.SceneManagement;
public class BotaoTrocaCena : MonoBehaviour
{
    [SerializeField] private string nomeDaCena;
    public void TrocarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}