using UnityEngine;
using TMPro;
using System.Collections;

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
        StartCoroutine(FadeInPanel());
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

    private IEnumerator FadeInPanel()
    {
        CanvasGroup canvasGroup = infoPanel.GetComponent<CanvasGroup>();
        infoPanel.SetActive(true);

        float duration = 0.3f;
        float elapsed = 0f;

        canvasGroup.alpha = 0f;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
