using UnityEngine;

public class FloatingIcon : MonoBehaviour
{
    public float floatStrength = 0.05f; // small bounce height
    public float floatSpeed = 2f;       // normal speed
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = startPos + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatStrength, 0);
    }
}
