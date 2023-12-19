using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxBarValue = 100f;
    public float depletionRate = 10f;
    public float currentBarValue;

    public GameObject YouLose;
    public Slider touch1;
    public GameObject youWinPanel; // Add a reference to the "You Win" panel

    private bool isCoroutineRunning = false;

    void Start()
    {
        currentBarValue = maxBarValue;
        touch1 = FindObjectOfType<Slider>();

        if (touch1 == null)
        {
            Debug.LogError("Slider component not found. Attach this script to a GameObject with a Slider component.");
        }

        // Find and assign the "You Win" panel
        youWinPanel = GameObject.Find("YouWinPanel"); // Replace "YouWinPanel" with the actual name
        if (youWinPanel != null)
        {
            youWinPanel.SetActive(false); // Deactivate the panel initially
        }
         YouLose = GameObject.Find("YouLose");
    }

    void Update()
    {
        touch1.value = currentBarValue;

        if (currentBarValue <= 0 && !isCoroutineRunning)
        {
            StartCoroutine(MyCoroutine());
        }
    }

    IEnumerator MyCoroutine()
    {
        isCoroutineRunning = true;

                // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        // Make the cursor visible
        Cursor.visible = true;

        Debug.Log("Coroutine started!");

        // Your coroutine logic goes here

        yield return new WaitForSeconds(3f);

        Debug.Log("Coroutine finished!");

        // Activate the "You Win" panel
        if (youWinPanel != null)
        {
            youWinPanel.SetActive(true);
                    // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        // Make the cursor visible
        Cursor.visible = true;
        }
        YouLose.SetActive(true);
        // Destroy the enemy object
        DestroyEnemy();


        // Reset the bar after the coroutine finishes
        currentBarValue = maxBarValue;
        isCoroutineRunning = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            currentBarValue -= depletionRate * Time.deltaTime;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
