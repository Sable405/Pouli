using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float timerDuration = 5f; // Adjust the timer duration as needed
    private float timer;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        timer = 0f;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 direction = player.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arm")) // Adjust the tag based on your arm object
        {
            // Arm touched the enemy
            audioManager.PlayEnemyTouchSound();
            StartTimer();
        }
    }

    void StartTimer()
    {
        timer = timerDuration;
    }

    void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            // Timer expired, do something
            Debug.Log("Timer expired!");
        }
    }
}
