using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;

    private bool timerFinished = false;

    public GameObject gameOverPanel; // Game Over output.

    public float t;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time + 80; //Time in seconds to count down from.
    }

    // Update is called once per frame
    void Update()
    {
        if (timerFinished)      //Timer finished bool.
            return;

        float t = Time.time - startTime; //Time variable.
        
        string minutes = ((int) -t / 60).ToString();  //Minutes string.
        string seconds = (-t % 60).ToString(format:"f1"); //Seconds string to one decimal place.

        timerText.text = minutes + ":" + seconds; //Text object output.

        if (t >= 0)                 //Timer stop and Game Over condition.
        {
            TimerStop();
            GameOver();
        }

    //Could also Stop timer with a collider with "IsTrigger" checked by attaching following code in a separate script to the GO with the collider on it.

    /*
    public void OnTriggerEnter(Collider other)
    {
    GameObject.Find("Player").SendMessage("TimerStop");
    }*/

    }

public void TimerStop()
{
timerText.color = Color.magenta;
timerFinished = true;

}
public void GameOver()
{
gameOverPanel.SetActive(true);
Destroy(gameObject);
}
}