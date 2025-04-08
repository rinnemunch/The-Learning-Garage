using TMPro;
using UnityEngine;

public class GearPointManager : MonoBehaviour
{
    public int gearPoints = 0;
    public TextMeshProUGUI gpText;

    void Start()
    {
        UpdateUI(); // show GP: 0 on load
    }

    public void AddPoints(int amount)
    {
        gearPoints += amount;
        UpdateUI(); 
        Debug.Log("Gear Points: " + gearPoints);
    }

    public int GetPoints()
    {
        return gearPoints;
    }

    public bool SpendPoints(int amount)
    {
        if (gearPoints >= amount)
        {
            gearPoints -= amount;
            UpdateUI(); 
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        if (gpText != null)
            gpText.text = "GP: " + gearPoints;
    }
}
