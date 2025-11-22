using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }*/
    public void PlayInfiniteMode()
    {
        GameMode.infiniteMode = true;
        SceneManager.LoadScene(1);
    }

    public void PlayNormalMode()
    {

        GameMode.infiniteMode = false;
        SceneManager.LoadScene(1);
    }
}
