using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)  || transform.position.y < -15)
        {
            transform.position = new Vector3(0, 0, 0);
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
