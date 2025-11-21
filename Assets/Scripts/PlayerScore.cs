using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public ChangeScoreTXT changeScore;
    public SoundManager soundManager;

    private void Start()
    {
        changeScore = FindAnyObjectByType<ChangeScoreTXT>();
        soundManager = FindAnyObjectByType<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.audioSource.PlayOneShot(soundManager.clipGainScore);
            changeScore.UpdateScore();
            Debug.Log("llego");
        }
    }
}
