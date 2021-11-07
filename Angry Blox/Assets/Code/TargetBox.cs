using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;
    bool alreadyScored = false;
    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.transform.tag == "Ground")
        {
            Scored();
        }
    }
    private void Scored()
    {
        if (!alreadyScored)
        {
            var sr = GetComponent<SpriteRenderer>();
            sr.color = Color.green;
            var rb = GetComponent<Rigidbody2D>();
            ScoreKeeper.AddToScore(rb.mass);
        }

        alreadyScored = true;
    }
}
