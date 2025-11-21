using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isInmortalDebug;

    private Rigidbody2D rb;
    [SerializeField] float jumpPower;
    public GameObject restartUI;
    public PlayerAudio playerAudio;

    public Animator animator;

    public bool isDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<PlayerAudio>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (isDead) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    private void FixedUpdate()
    {
     GravityDown();   
    }
    
    private void GravityDown()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (2f - 1) * Time.fixedDeltaTime;
        }
    }
    private void PlayerJump()
    {
        playerAudio.AudioSource.PlayOneShot(playerAudio.jump);
        rb.linearVelocityY = jumpPower;
    }

    public void DeadPlayer()
    {
        if (isDead) return;
        isDead = true;
        playerAudio.AudioSource.PlayOneShot(playerAudio.dead);
        animator.SetTrigger("Die");
        restartUI.SetActive(true);

        StartCoroutine(PauseAfterAnimation());
    }

    IEnumerator PauseAfterAnimation()
    {
        yield return new WaitForSecondsRealtime(0.5f); // deja que empiece la animación
        Time.timeScale = 0f;
    }

}
