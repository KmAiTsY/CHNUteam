using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public GroundDetection groundDetection;
    public Animator animator;
    private Vector3 direction;
    public float speed;
    public float force;
    public float minimalHeight;
    public bool isCheatMode;
    public bool isJumping;
    void FixedUpdate()
    {
        animator.SetBool("isGrouded", groundDetection.isGrouded);
        if(!isJumping && !groundDetection.isGrouded)
        {
            animator.SetTrigger("StartFall");
        }
        isJumping = isJumping && !groundDetection.isGrouded;
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(0.158113f, -0.08469892f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(-0.158113f, -0.08469892f);
        }
        direction *= speed;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;
        animator.SetFloat("Speed", Mathf.Abs(direction.x));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && groundDetection.isGrouded)
        {
            rigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
            animator.SetTrigger("StartJump");
            isJumping = true;
        }
        
        CheckFall();
    }
    void CheckFall()
    {
        if ((Input.GetKeyDown(KeyCode.R) || transform.position.y < minimalHeight) && isCheatMode)
        {
            SceneManager.LoadScene(0);
            /*rigidbody.velocity = new Vector2(0, 0);
            transform.position = new Vector2(-9, 0);*/
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
        {
            Destroy(gameObject);
        }
    }
}
