using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxBarValue = 100f;
    public float depletionRate = 10f;
    public float currentBarValue;
 

    public Slider touch1; // Change 'Touch2' to 'touch2'

    private bool isCoroutineRunning = false;

    void Start()
    {
        currentBarValue = maxBarValue;

        // Change 'Touch2' to 'touch2' for consistency
        touch1 = FindObjectOfType<Slider>();
        if (touch1 == null)
        {
            Debug.LogError("Slider component not found. Attach this script to a GameObject with a Slider component.");
        }

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

        Debug.Log("Coroutine started!");

        // Your coroutine logic goes here

        yield return new WaitForSeconds(3f); // Adjust the duration as needed

        Debug.Log("Coroutine finished!");

        // Destroy the enemy object
        DestroyEnemy();

        // Increment the counter
        //   enemyDestroyedCount++;

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

   // void OnDestroy()
 //   {
        // Notify the GameController when an enemy is destroyed
     //   if (counter != null)
      //  {
    //        counter.EnemyDestroyed();
      //  }
   // }

    private void DestroyEnemy()
    {
      // Call the method from 'counter' script
        // Assuming this script is attached to the enemy object
        Destroy(gameObject);
    }
}
