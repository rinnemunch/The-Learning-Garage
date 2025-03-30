using UnityEngine;
using TMPro;

public class ProgressTracker : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    public int totalParts = 3;
    private int inspectedParts = 0;

    public void AddProgress()
    {
        inspectedParts++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        progressText.text = $"Parts Inspected: {inspectedParts} of {totalParts}";
    }
}
