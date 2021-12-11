using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMove : MonoBehaviour
{
    Rigidbody rb;
    public float SpeedUp = 1000;
    public float SpeedForward = 1f;
    public AudioClip jetSound;
    public ParticleSystem boostpt;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Vector3 ThrustForce = Vector3.up * SpeedUp * Time.deltaTime;
            rb.AddRelativeForce(ThrustForce);
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(jetSound);
            }
            if (!boostpt.isPlaying)
            {
                boostpt.Play();
            }
            
        }
        else
        {
            audio.Stop();
            boostpt.Stop();
        }

        if (Input.GetKey("left"))
        {
            rb.freezeRotation = true;
            Vector3 ThrustForceR = Vector3.forward * SpeedForward * Time.deltaTime;
            transform.Rotate(ThrustForceR);
            rb.freezeRotation = false;

        }
        else if (Input.GetKey("right"))
        {
            rb.freezeRotation = true;
            Vector3 ThrustForceRR = -Vector3.forward * SpeedForward * Time.deltaTime;
            transform.Rotate(ThrustForceRR);
            rb.freezeRotation = false;
        }
    }
}
