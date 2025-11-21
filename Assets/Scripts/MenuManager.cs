using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        SceneManager.LoadScene(0);
    }

    public void PlayNormalMode()
    {

        GameMode.infiniteMode = false;
        SceneManager.LoadScene(0);
    }
}
