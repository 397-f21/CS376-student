using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class objInteraction : MonoBehaviour
{
    AudioSource audio;
    public AudioClip land;
    public AudioClip crash;
    public AudioClip getFruit;
    public ParticleSystem greenPt;
    public ParticleSystem yellowPt;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            audio.PlayOneShot(land);
            greenPt.Play();
            GetComponent<birdMove>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Invoke("GoToNext", 1f);

        }
        else if(collision.gameObject.tag != "platform")
        {
            audio.Stop();
            audio.PlayOneShot(crash);
            yellowPt.Play();
            GetComponent<birdMove>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Invoke("GoToStartScene", 3f);
            
        }
    }

    
    void GoToNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            GoToStartScene();
        }
    }
    void GoToStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
