using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
[System.Serializable]
public class Question
{
   [TextArea(2, 4)]
   public string statement;
   public string[] options = new string[3];
   public int correctIndex;
}
public class GameManagerDebate : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text questionText;
    public Button[] optionButtons;
    public TMP_Text reputationText;
    public GameObject panelMessage;
    public TMP_Text messageText;
    [Header("Perguntas")]
    public Question[] questions;
    private int currentQuestion = 0;
    private int reputation = 0;
    void Start()
    {
        ShowQuestion();
        UpdateReputation();
    }
    void ShowQuestion()
    {
        if (currentQuestion >= questions.Length)
        {
            EndDebate();
            return;
        }
        Question q = questions[currentQuestion];
        questionText.text = q.statement;
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            TMP_Text buttonText = optionButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = q.options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => ChooseOption(index));
        }
    }
    void ChooseOption(int index)
    {
        bool correct = index == questions[currentQuestion].correctIndex;
        if (correct)
        {
            reputation++;
            ShowMessage("O público aplaude!");
        }
        else
        {
            reputation--;
            ShowMessage("O público murmura...");
        }
        UpdateReputation();
        currentQuestion++;
        Invoke(nameof(ShowQuestion), 1.5f);
    }
    void UpdateReputation()
    {
        reputationText.text = "Reputação: " + reputation;
    }
    void EndDebate()
    {
        if (reputation >= 2)
            SceneManager.LoadScene("Ending_Vitoria");
        else
            SceneManager.LoadScene("Ending_Neutra");
    }
    void ShowMessage(string msg)
    {
        if (panelMessage)
        {
            panelMessage.SetActive(true);
            messageText.text = msg;
            Invoke(nameof(HideMessage), 1.3f);
        }
    }
    void HideMessage()
    {
        if (panelMessage)
            panelMessage.SetActive(false);
    }
}
