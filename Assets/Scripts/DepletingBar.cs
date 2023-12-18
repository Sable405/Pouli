using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DepletingBar : MonoBehaviour
{
    public float maxBarValue = 100f;
    public float depletionRate = 10f;
    public float currentBarValue;

    public Slider Touch2;
    private bool isCoroutineRunning = false;

    void Start()
    {
        currentBarValue = maxBarValue;
       Touch2 = FindObjectOfType<Slider>();
        if (Touch2 == null)
        {
            Debug.LogError("Slider component not found. Attach this script to a GameObject with a Slider component.");
        }
       
    }

    void Update()
    {
         
        
        // Uncomment this if you want to deplete the bar continuously
      Touch2.value = currentBarValue;

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

        currentBarValue = maxBarValue; // Reset the bar after coroutine finishes
        isCoroutineRunning = false;
    }

    private void OnTriggerStay(Collider other)
    {
      
        if (other.CompareTag("Arm")) // Assuming "Arm" is the correct tag
        {
            currentBarValue -= depletionRate * Time.deltaTime;
           // Touch2.value = currentBarValue;
            
        }
        
    }
}
