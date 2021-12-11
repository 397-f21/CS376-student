using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMove : MonoBehaviour
{
    public GameObject points1;
    public GameObject points2;
    private float moveSpeed = 3f;
    private Vector3 target;

    private void FixedUpdate()
    {
        if(transform.position == points1.transform.position)
        {
            target = points2.transform.position;
        }else if (transform.position == points2.transform.position)
        {
            target = points1.transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("knight"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("knight"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
