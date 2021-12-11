using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KnightMotion : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer sr;

    private BoxCollider2D bc;
    bool isGrounded = true;
    private enum KnightState { idle, run, jump, fall}
    private KnightState ks;
    private int score = 0;
    public Text score_test;
    private bool isDead = false;
    private float moveSpeed = 7f;
    private float moveSpeedY = 1f;

    public AudioSource jumpSound;
    public AudioSource coinSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y* moveSpeedY);
        }
        else
        {
            moveSpeed = 0f;
            moveSpeedY = 0f;
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown("space") && isGrounded)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, 15f);
        }
        if(Input.GetAxis("Horizontal") > 0f)
        {
            ks = KnightState.run;
            sr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            ks = KnightState.run;
            sr.flipX = true;
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            ks = KnightState.idle;
        }

        if(rb.velocity.y > .5f)
        {
            ks = KnightState.jump;
        }
        if (rb.velocity.y < -.5f)
        {
            ks = KnightState.fall;
        }


        animator.SetInteger("state", (int)ks);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("terrain") || collision.gameObject.CompareTag("wood"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("trap"))
        {

            loseSound.Play();
            animator.SetTrigger("death");
            isDead = true;
        }

        if (collision.gameObject.CompareTag("checkpoint"))
        {

            winSound.Play();
            Invoke("LoadLWin", 2.0f);
        }
    }
    void LoadLWin()
    {
        SceneManager.LoadScene(1);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("terrain") || collision.gameObject.CompareTag("wood"))
        {
            isGrounded = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("taco"))
        {
            coinSound.Play();
            Destroy(collision.gameObject);
            score += 1;
            score_test.text = "Score: " + score;
        }

    }

    private void startOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
