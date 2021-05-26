using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public GameObject leftButton;
    public GameObject rightButton;
    public float speed;
    public float force;
    public float minimalHeight;
    public bool isCheatMode;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(1.565558f, -0.8419857f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(-1.565558f, -0.8419857f);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
        }

        if ((Input.GetKeyDown(KeyCode.R) || transform.position.y < minimalHeight) && isCheatMode)
        {
            rigidbody.velocity = new Vector2(0, 0);
            transform.position = new Vector2(0, 0);
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
        {
            Destroy(gameObject);
        }
    }
}
