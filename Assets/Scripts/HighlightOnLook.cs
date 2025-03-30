using UnityEngine;

public class HighlightOnLook : MonoBehaviour
{
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    public void Highlight(bool shouldHighlight)
    {
        rend.material = shouldHighlight ? highlightMaterial : originalMaterial;
    }
}
