using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip enemyTouchSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyTouchSound()
    {
        audioSource.PlayOneShot(enemyTouchSound);
    }
}
