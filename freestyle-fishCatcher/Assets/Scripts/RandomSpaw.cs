using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpaw : MonoBehaviour
{
    public float upperLimit = 4.2f;
    public float lowerLimit = -4.2f;
    public GameObject fish1Prefab;
    public GameObject fish2Prefab;
    public GameObject o1Prefab;
    public GameObject shark1Prefab;
    public float tiFish1 = 5.5f;
    public float tiFish2 = 14.8f;
    public float tiO1 = 26.3f;
    public float tiShark1 = 38.2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnFish1", tiFish1);
        Invoke("SpawnFish2", tiFish2);
        Invoke("SpawnO1", tiO1);
        Invoke("SpawnShark1", tiShark1);

    }
    
    void SpawnFish1()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = Random.Range(lowerLimit, upperLimit);
        Instantiate(fish1Prefab, currentPos, Quaternion.identity);
        Invoke("SpawnFish1", tiFish1);
    }
    void SpawnFish2()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = Random.Range(lowerLimit, upperLimit);
        Instantiate(fish2Prefab, currentPos, Quaternion.identity);
        Invoke("SpawnFish2", tiFish2);
    }

    void SpawnO1()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = Random.Range(lowerLimit, upperLimit);
        Instantiate(o1Prefab, currentPos, Quaternion.identity);
        Invoke("SpawnO1", tiO1);
    }

    void SpawnShark1()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = Random.Range(lowerLimit, upperLimit);
        Instantiate(shark1Prefab, currentPos, Quaternion.identity);
        Invoke("SpawnShark1", tiShark1);
    }

}
