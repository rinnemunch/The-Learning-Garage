using UnityEngine;

public class GarageLightToggle : MonoBehaviour
{
    public Light[] garageLights; // Real point lights
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            foreach (Light light in garageLights)
                light.enabled = !light.enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
