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
            if (audioSource.isPlaying)
                audioSource.Stop(); 

            audioSource.clip = songs[index];
            audioSource.Play();
        }
        else
        {
            Debug.Log("Track " + index + " is locked.");
        }
    }


    public void TryUnlockAndPlay(int index)
    {
        if (unlocked[index])
        {
            PlayTrack(index); // Already unlocked
        }
        else
        {
            GearPointManager gpManager = FindObjectOfType<GearPointManager>();
            if (gpManager != null && gpManager.SpendPoints(25))
            {
                unlocked[index] = true;
                PlayTrack(index); // Unlock and play
                Debug.Log("Track " + index + " unlocked and playing.");
            }
            else
            {
                Debug.Log("Not enough Gear Points to unlock Track " + index);
            }
        }
    }


}
