using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class ChangeScoreTXT : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text maxScoreText;
    public GameObject finalScreen;
    public GameObject exitScreen;
    public GameObject deadScreen;
    public SoundManager soundManager;
    public int score;
    public int maxScore;

    public bool menuPressed = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPressed();
        }
    }
    private void Awake()
    {
        if (!GameMode.infiniteMode) { scoreText.text = "Score 0 / 8000"; } else { scoreText.text = "Score 0"; }
    }

    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        maxScoreText.text = $"Max Score: {maxScore}";
    }
    public void UpdateScore()
    {
        score += 100;
        if (score >= 8000 && !GameMode.infiniteMode) { FinalScreen(); }
        if (score >= maxScore )
        {
            maxScore = score;
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.Save();
        }
        maxScoreText.text = $"Max Score: {maxScore}";
        if (GameMode.infiniteMode) { scoreText.text = "Score " + score.ToString(); }
        else { scoreText.text = $"Score {score} / 8000"; }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void FinalScreen() 
    {
        Time.timeScale = 0f;
        finalScreen.SetActive(true);
        soundManager.audioSource.PlayOneShot(soundManager.clipWinScreen);
    }

    public void MenuPressed()
    {
        if (finalScreen.activeSelf || deadScreen.activeSelf) return;
       
        menuPressed = !menuPressed;

        Time.timeScale = menuPressed ? 0f : 1f;

        exitScreen.SetActive(menuPressed);
    }

}
