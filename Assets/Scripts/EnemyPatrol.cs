using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rigidbody;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Animator animator;
    public GroundDetection groundDetection;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollisionDamage collisionDamage;
    public bool isRightDirection;
    public float speed;
    void Update()
    {
        if(groundDetection.isGrounded)
        {
            if(transform.position.x > rightBorder.transform.position.x || collisionDamage.Direction < 0)
            {
                isRightDirection = false;
            }
            else if (transform.position.x < leftBorder.transform.position.x || collisionDamage.Direction > 0)
            {
                isRightDirection = true;
            }
            rigidbody.velocity = isRightDirection ? Vector2.right : Vector2.left;
            rigidbody.velocity *= speed;
        }
        if (rigidbody.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (rigidbody.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
