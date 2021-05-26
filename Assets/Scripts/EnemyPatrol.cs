using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public bool isRightDirection;
    public float speed;
    void Update()
    {
        if(isRightDirection)
        {
            /*rigidbody.velocity = new Vector2(1 * speed, 0);*/
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > rightBorder.transform.position.x)
            {
                isRightDirection = !isRightDirection;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        else
        {
            /*rigidbody.velocity = new Vector2(-1 * speed, 0);*/
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < leftBorder.transform.position.x)
            {
                isRightDirection = !isRightDirection;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }
}
