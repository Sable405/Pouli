using UnityEngine;

public class AudioMan2 : MonoBehaviour
{
    public AudioClip enemyTouchSound1;
    public AudioClip enemyTouchSound2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource is properly initialized
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Attach an AudioSource component to the AudioManager GameObject.");
        }
        else{
            Debug.Log("AudioSource successfully initialized.");
        }
    }

    public void PlayEnemyTouchSound2()
    {
        // Check if audioSource is null before attempting to play a sound
        if (audioSource != null)
        {
            int randomIndex = Random.Range(0, 2);
            AudioClip selectedClip = (randomIndex == 0) ? enemyTouchSound1 : enemyTouchSound2;
            audioSource.PlayOneShot(selectedClip);
        }
        else
        {
            Debug.LogError("AudioSource is null. Make sure it is properly initialized in the Start method.");
        }
    }
}
