using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewall1 : MonoBehaviour
{
    public float movespeed = 1f;
    Vector3 start;
    Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        start = new Vector3(-10, 8, -5);
        end = new Vector3(-15, 8, -5);

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.Lerp(start, end, Mathf.PingPong(Time.time * movespeed, 1));

    }
}
