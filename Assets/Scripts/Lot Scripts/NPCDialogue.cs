using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    private int currentLine = 0;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = lines[currentLine];
        currentLine = (currentLine + 1) % lines.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialoguePanel.SetActive(false);
        }
    }
}
