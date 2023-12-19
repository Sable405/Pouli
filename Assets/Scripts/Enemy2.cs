using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public float maxBarValue = 100f;
    public float depletionRate = 10f;
    public float currentBarValue;

    public Slider Touch22;
    private bool isCoroutineRunning = false;

    public Counter Counter;

 //   private AudioMan2 AudioMan2;

    void Start()
    {
       // AudioMan2 = FindObjectOfType<AudioMan2>();
        currentBarValue = maxBarValue;
       Touch22 = FindObjectOfType<Slider>();
        if (Touch22 == null)
        {
            Debug.LogError("Slider component not found. Attach this script to a GameObject with a Slider component.");
        }
        else{
            Touch22.value = currentBarValue;
        }
       
    }

    void Update()
    {
         
        
        // Uncomment this if you want to deplete the bar continuously
      Touch22.value = currentBarValue;

        if (currentBarValue <= 0 && !isCoroutineRunning)
        {
            StartCoroutine(MyCoroutine());
            Counter.EnemyDestroyed();
            Destroy(gameObject);
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
