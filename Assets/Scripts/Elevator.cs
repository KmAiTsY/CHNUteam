using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject topBorder;
    public GameObject bottomBorder;
    public float speed;
    public bool isUpDirection;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isUpDirection)
        {
            /*rigidbody.velocity = new Vector2(1 * speed, 0);*/
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y > topBorder.transform.position.y)
            {
                isUpDirection = !isUpDirection;
            }
        }
        else
        {
            /*rigidbody.velocity = new Vector2(-1 * speed, 0);*/
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < bottomBorder.transform.position.y)
            {
                isUpDirection = !isUpDirection;
            }
        }
    }
}
