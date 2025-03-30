using UnityEngine;
using TMPro;

public class CarPartInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI partNameText;
    public TextMeshProUGUI descriptionText;
    public AudioClip inspectSound;

    [Header("Part Info")]
    public string partName;
    [TextArea] public string description;

    [Header("Optional")]
    public GameObject floatingIcon;

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
        partNameText.text = partName;
        descriptionText.text = description;

        if (floatingIcon != null)
            floatingIcon.SetActive(false);
        FindObjectOfType<ProgressTracker>().AddProgress();
        AudioSource.PlayClipAtPoint(inspectSound, transform.position);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }
}
