using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFish : MonoBehaviour

{
    public float movingSpeed = 5f;
    public Transform shoot_Pos;
    private Animator moving;
    private AudioSource getHitAudio;
    public GameObject bubblePrefab;
    public bool HitByNet = false;
    private void Awake()
    {
        moving = GetComponent<Animator>();
        getHitAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("autoShootBubble", Random.Range(1f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        transform.position = new Vector3(currentPos.x - movingSpeed * Time.deltaTime, currentPos.y, currentPos.z);
        if (HitByNet)
        {
            movingSpeed = 0f;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void autoShootBubble()
    {
        GameObject bubble = Instantiate(bubblePrefab, shoot_Pos.position, Quaternion.identity);
        bubble.GetComponent<ShootNet>().IsBubble = true;
        Invoke("autoShootBubble", Random.Range(1f, 5f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("net"))
        {
            if (gameObject.tag == "fish1")
            {
                HitByNet = true;
                moving.Play("fish1Gethit");
                ScoreKeeper.AddToScore(1f);
                Destroy(gameObject,1f);
            }
            if (gameObject.tag == "fish2")
            {
                HitByNet = true;
                moving.Play("fish2Gethit");
                ScoreKeeper.AddToScore(2f);
                Destroy(gameObject, 1f);
            }
            if (gameObject.tag == "o1")
            {
                HitByNet = true;
                moving.Play("o1GetHit");
                ScoreKeeper.AddToScore(5f);
                Destroy(gameObject, 1f);
            }
            if (gameObject.tag == "shark1")
            {
                HitByNet = true;
                moving.Play("shark1Gethit");
                ScoreKeeper.AddToScore(10f);
                Destroy(gameObject, 1f);
            }
            getHitAudio.Play();

        }

        if (collision.CompareTag("player"))
        {
            Destroy(gameObject);
            countDownTimer.Restart();
        }
      
    }
}
