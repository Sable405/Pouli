using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip enemyTouchSound1;
    public AudioClip enemyTouchSound2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyTouchSound()
    {
          int randomIndex = Random.Range(0, 2);
         AudioClip selectedClip = (randomIndex == 0) ? enemyTouchSound1 : enemyTouchSound2;
          audioSource.PlayOneShot(selectedClip);
    }
}
