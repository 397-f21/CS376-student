using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSubmarine : MonoBehaviour
{
    public GameObject netPrefab;
    public Transform shoot_Pos;
    public float coolDown = .5f;
    public float movingSpeed = 5f;
    public float upperLimit = 4.2f;
    public float lowerLimit = -4.2f;
    public bool iscoolDown;
    public float currentTime;
    private float coolDownTime = 0.5f;
    private AudioSource shootNetAudio;
    void Awake()
    {
        shootNetAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        iscoolDown = false;
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if(currentTime > coolDownTime)
        {
            iscoolDown = false;
        }
        if (Input.GetKey("up"))
        {
            Vector3 newPosition = transform.position;
            if(newPosition.y > upperLimit)
            {
                newPosition.y = upperLimit;
            }
            transform.position = new Vector3(newPosition.x, newPosition.y + movingSpeed * Time.deltaTime, newPosition.z);
        }
        if (Input.GetKey("down"))
        {
            Vector3 newPosition = transform.position;
            if (newPosition.y < lowerLimit)
            {
                newPosition.y = lowerLimit;
            }
            transform.position = new Vector3(newPosition.x, newPosition.y - movingSpeed * Time.deltaTime, newPosition.z);
        }

        if (Input.GetKeyDown("space") && !iscoolDown)
        {
            iscoolDown = true;
            Instantiate(netPrefab, shoot_Pos.position, Quaternion.identity);
            currentTime = 0f;

            shootNetAudio.Play();
        }
    }

}
