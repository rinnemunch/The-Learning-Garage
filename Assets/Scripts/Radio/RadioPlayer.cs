using UnityEngine;

public class RadioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] songs;
    public bool[] unlocked;
    private int currentTrack = 0;

    public void PlayNextTrack()
    {
        currentTrack = (currentTrack + 1) % songs.Length;

        if (unlocked[currentTrack])
        {
            audioSource.clip = songs[currentTrack];
            audioSource.Play();
        }
    }

    public void UnlockTrack(int index)
    {
        if (index >= 0 && index < unlocked.Length)
            unlocked[index] = true;
    }

    public void PlayTrack(int index)
    {
        if (unlocked[index])
        {
            audioSource.clip = songs[index];
            audioSource.Play();
        }
        else
        {
            Debug.Log("Track is locked!");
        }
    }

}
