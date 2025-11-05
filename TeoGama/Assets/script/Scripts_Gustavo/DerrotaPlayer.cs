using UnityEngine;

public class DerrotaPlayer : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}