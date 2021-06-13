using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rigidbody;
    public float minimalHeight = -15f;
    float x, y;
    private void Start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
    }
    private void Update()
    {
        CheckFall();
    }
    void CheckFall()
    {
        if (transform.position.y < minimalHeight)
        {
            transform.position = new Vector3(x, y);
            rigidbody.velocity = new Vector2(0, 0);
        }
    }
}
