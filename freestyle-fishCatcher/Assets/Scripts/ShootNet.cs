using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootNet : MonoBehaviour
{
    public float shootSpeed = 5f;
    public bool IsBubble = false;
    // Start is called before the first frame update
    void Start()
    {
        if (IsBubble)
        {
            shootSpeed *= -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        transform.position = new Vector3(newPos.x + shootSpeed * Time.deltaTime, newPos.y, newPos.z);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsBubble)
        {
            if (collision.CompareTag("bubble") || collision.CompareTag("fish1")|| collision.CompareTag("fish2")|| collision.CompareTag("o1")|| collision.CompareTag("shark1"))
            {
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("net"))
        {
            Destroy(gameObject);
        }else if (collision.CompareTag("player"))
        {
            Destroy(gameObject);
            countDownTimer.Restart();
        }
    }
}
