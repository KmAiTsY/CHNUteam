using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform finishBorder;
    public Transform startBorder;
    public Rigidbody2D rigidbody;
    public bool direction;
    public float speed;
    void FixedUpdate()
    {
        if (direction)
        {
            Vector2 movePosition = transform.position;
            movePosition = Vector2.MoveTowards(transform.position, finishBorder.transform.position, speed * Time.deltaTime);
            rigidbody.MovePosition(movePosition);
            if (Vector2.Distance(transform.position, finishBorder.transform.position) < 0.2f)
            {
                direction = !direction;
            }
        }
        else
        {
            Vector2 movePosition = transform.position;
            movePosition = Vector2.MoveTowards(transform.position, startBorder.transform.position, speed * Time.deltaTime);
            rigidbody.MovePosition(movePosition);
            if (Vector2.Distance(transform.position, startBorder.transform.position) < 0.2f)
            {
                direction = !direction;
            }
        }
    }
}
