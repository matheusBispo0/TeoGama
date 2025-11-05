using TMPro;
using UnityEngine;

public class DialogoPainel : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject interactUI;
    public GameObject dialogPanel;
    public TMP_Text npcNameText;
    public TMP_Text dialogText;

    [Header("NPC Info")]
    public string npcName = "NPC";
    [TextArea] public string[] dialogLines;

    private bool isPlayerNear = false;
    private int currentLine = 0;
    private bool inDialogue = false;

    void Start()
    {
        interactUI.SetActive(false);
        dialogPanel.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && !inDialogue && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
        else if (inDialogue && Input.GetKeyDown(KeyCode.E))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        inDialogue = true;
        interactUI.SetActive(false);
        dialogPanel.SetActive(true);
        npcNameText.text = npcName;
        currentLine = 0;
        dialogText.text = dialogLines[currentLine];
        
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        inDialogue = false;
        dialogPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (!inDialogue) interactUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactUI.SetActive(false);
            if (inDialogue) EndDialogue();
        }
    }
}