using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScoreTXT : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text maxScoreText;
    public int score;
    public int maxScore;

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
        SceneManager.LoadScene(0);
    }

}
