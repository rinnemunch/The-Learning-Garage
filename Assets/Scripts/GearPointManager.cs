using UnityEngine;

public class GearPointManager : MonoBehaviour
{
    public int gearPoints = 0;

    public void AddPoints(int amount)
    {
        gearPoints += amount;
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
            return true;
        }
        return false;
    }
}
