using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepletingBar : MonoBehaviour
{
    public float maxBarValue = 100f;
    public float depletionRate = 10f;
    public float currentBarValue;

    private bool isCoroutineRunning = false;

    void Start()
    {
        currentBarValue = maxBarValue;
    }

    void Update()
    {
       

        if (currentBarValue <= 0 && !isCoroutineRunning)
        {
            StartCoroutine(MyCoroutine());
        }
    }

    void DepleteBar()
    {
        currentBarValue -= depletionRate * Time.deltaTime;
        currentBarValue = Mathf.Clamp(currentBarValue, 0f, maxBarValue);
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
   
   private void OnTriggerEnter(Collider other)
   {
     if (other.tag == "Arm") // Assuming left mouse button is used for touch
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("DepletingBar"))
                {
                    DepleteBar();
                }
            }
        }
     }
     }


