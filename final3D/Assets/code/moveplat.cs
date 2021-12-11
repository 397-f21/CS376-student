using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplat : MonoBehaviour
{
    public float movespeed = 1f;
    Vector3 start;
    Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        start = new Vector3(0, 0, -5);
        end = new Vector3(-5, 0, -5);

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.Lerp(start, end, Mathf.PingPong(Time.time * movespeed, 1));

    }
}
