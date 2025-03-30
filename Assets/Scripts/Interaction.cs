using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera playerCamera;
    private CarPartInfo currentPart;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If a panel is already open, close it
            if (currentPart != null)
            {
                currentPart.HideInfo();
                currentPart = null;
                return;
            }

            // Raycast from the camera forward
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            {
                if (hit.collider.CompareTag("Inspectable"))
                {
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
