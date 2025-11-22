using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipGainScore;
    public AudioClip clipWinScreen;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
