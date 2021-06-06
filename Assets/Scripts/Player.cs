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
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private UIPlayerController controller;
    private void Awake()
    {
        Instance = this;
    }
    void FixedUpdate()
    {
        Move();
        animator.SetFloat("Speed", Mathf.Abs(direction.x));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Jump();
        CheckFall();
    }
    #region Singleton
    public static Player Instance { get; set; }
    #endregion
    public void InitPlayerController(UIPlayerController uiController)
    {
        controller = uiController;
        controller.Jump.onClick.AddListener(Jump);
        controller.Shoot.onClick.AddListener(Shoot);
    }
    private void Jump()
    {
        if (groundDetection.isGrounded)
        {
            rigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
            animator.SetTrigger("StartJump");
            isJumping = true;
        }
    }
    private void Move()
    {
        animator.SetBool("isGrouded", groundDetection.isGrounded);
        direction = Vector3.zero;
        if (!isJumping && !groundDetection.isGrounded)
            animator.SetTrigger("StartFall");
        isJumping = isJumping && !groundDetection.isGrounded;
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            boxCollider.offset = new Vector2(0.158113f, -0.08469892f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            boxCollider.offset = new Vector2(-0.158113f, -0.08469892f);
        }
#endif
        if (controller.Left.IsPressed || Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            boxCollider.offset = new Vector2(0.158113f, -0.08469892f);
        }
        if (controller.Right.IsPressed || Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            boxCollider.offset = new Vector2(-0.158113f, -0.08469892f);
        }
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
        direction *= speed;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        if (direction.x < 0)
            spriteRenderer.flipX = true;
    }
    void Shoot()
    {
        animator.SetTrigger("Shoot");
        GameObject prefab = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
        prefab.GetComponent<Bullet>().SetImpulse(Vector2.right, spriteRenderer.flipX ? -force * 10 : force * 10);
    }
    void CheckFall()
    {
        if ((Input.GetKeyDown(KeyCode.R) || transform.position.y < minimalHeight) && isCheatMode)
        {
            SceneManager.LoadScene(2);
            /*rigidbody.velocity = new Vector2(0, 0);
            transform.position = new Vector2(-9, 0);*/
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
        {
            Destroy(gameObject);
        }
    }
}
