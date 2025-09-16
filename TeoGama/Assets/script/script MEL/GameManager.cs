using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour

{

    public static GameManager instance;
    public TMP_Text scoreText;
    private int score = 0;

    void Awake()

    {
        instance = this;
    }

    public void AddPoint()

    {

        score++;
        scoreText.text = "Encontrados: " + score;

    }

}
