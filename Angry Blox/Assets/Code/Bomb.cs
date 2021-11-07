using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;


    private void Destruct()
    {
        Destroy(gameObject);
    }

    private void Boom()
    {
        ///Turning on the PointEffector2D
        var pe = GetComponent<PointEffector2D>();
        pe.enabled = true;
        ///Turning off the box’s SpriteRenderer
        var sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= ThresholdForce)
        {
            Boom();
        }
    }
}


