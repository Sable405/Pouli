using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName = "Scene1"; // Change this to the name of your next scene
    public string two = "Scene2"; // Change this to the name of your next scene
    public string three = "Scene3"; // Change this to the name of your next scene


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to the key you want to use
        {
            SwitchToNextScene();
        }
    }

    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
         
        //  SceneManager.LoadScene(three);
    }
    public void Seeen()
    {
        SceneManager.LoadScene(two);
    }
}
