using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int enemyCount = 3;

    void Start()
    {
        UpdateCounterText();
    }

    public void EnemyDestroyed()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            LoadNextScene();
        }
        else
        {
            UpdateCounterText();
        }
    }

    void UpdateCounterText()
    {
        counterText.text = "Counter: " + enemyCount.ToString();
    }

    void LoadNextScene()
    {
        // You can modify this line to load the actual next scene you want.
        SceneManager.LoadScene("YourNextSceneName");
    }
}
