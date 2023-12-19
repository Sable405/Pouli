using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;
    public float accelerationMultiplier = 2f;
    public float accelerationDuration = 5f;
    private bool isAccelerating = false;

    private void Start()
    {
        // Find the player using the tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Rotate to face the player
            RotateTowardsPlayer();

            // Move towards the player
            MoveTowardsPlayer();

            // Handle acceleration
            HandleAcceleration();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    private void MoveTowardsPlayer()
    {
        float speed = isAccelerating ? moveSpeed * accelerationMultiplier : moveSpeed;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void HandleAcceleration()
    {
        if (!isAccelerating)
        {
            StartCoroutine(AccelerateForDuration());
        }
    }

    private System.Collections.IEnumerator AccelerateForDuration()
    {
        isAccelerating = true;

        // Speed up for a duration
        moveSpeed *= accelerationMultiplier;

        yield return new WaitForSeconds(accelerationDuration);

        // Slow down after the duration
        moveSpeed /= accelerationMultiplier;
        isAccelerating = false;
    }
}
