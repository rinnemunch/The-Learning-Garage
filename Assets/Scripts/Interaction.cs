using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera playerCamera;
    private CarPartInfo currentPart;
    private HighlightOnLook currentHighlight;

    void Update()
    {
        // Reset previous highlight
        if (currentHighlight != null)
        {
            currentHighlight.Highlight(false);
            currentHighlight = null;
        }

        // Raycast from camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.CompareTag("Inspectable"))
            {
                // Highlight part if possible
                HighlightOnLook highlight = hit.collider.GetComponent<HighlightOnLook>();
                if (highlight != null)
                {
                    highlight.Highlight(true);
                    currentHighlight = highlight;
                }

                // Interact if E is pressed
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (currentPart != null)
                    {
                        currentPart.HideInfo();
                        currentPart = null;
                        return;
                    }

                    CarPartInfo part = hit.collider.GetComponent<CarPartInfo>();
                    if (part != null)
                    {
                        part.ShowInfo();
                        currentPart = part;
                    }
                }
            }
        }
    }
}
