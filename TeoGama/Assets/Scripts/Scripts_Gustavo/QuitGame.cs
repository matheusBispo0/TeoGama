using UnityEngine;

using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void QuitMenu()
    {
        SceneManager.LoadScene("iniciar (Melissa)");
        Time.timeScale = 1.0f;
    }

}
 