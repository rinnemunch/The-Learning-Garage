using UnityEngine;

public class CarPaintController : MonoBehaviour
{
    public Material yellowMat;
    public Material redMat;
    public Material blueMat;
    public Renderer carRenderer;

    public bool redUnlocked = false;
    public bool blueUnlocked = false;

    public void SetYellow()
    {
        ApplyMaterial(yellowMat);
    }

    public void TryUnlockRed()
    {
        if (!redUnlocked && FindObjectOfType<GearPointManager>().SpendPoints(50))
            redUnlocked = true;

        if (redUnlocked)
            ApplyMaterial(redMat);
    }

    public void TryUnlockBlue()
    {
        if (!blueUnlocked && FindObjectOfType<GearPointManager>().SpendPoints(50))
            blueUnlocked = true;

        if (blueUnlocked)
            ApplyMaterial(blueMat);
    }

    private void ApplyMaterial(Material newMat)
    {
        Material[] mats = carRenderer.materials;
        mats[2] = newMat; //  Targeting the body (Element 2)
        carRenderer.materials = mats;
    }
}
