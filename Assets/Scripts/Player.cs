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
    public BoxCollider2D legs;
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
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private float shootForce;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float shootTime;
    [SerializeField] private float laddingSpeed;
    [SerializeField] PlayerInventory playerInventory;
    private UIPlayerController controller;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        transform.position = playerSpawnPoint.transform.position;
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
        if (controller.Left.IsPressed || Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            boxCollider.offset = new Vector2(0.158113f, -0.08033466f);
            legs.offset = new Vector2(0.158113f, -0.6283782f);
        }
        if (controller.Right.IsPressed || Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            boxCollider.offset = new Vector2(-0.158113f, -0.08033466f);
            legs.offset = new Vector2(-0.158113f, -0.6283782f);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("Ladding");
            rigidbody.velocity = Vector2.up * laddingSpeed;
        }
    }
    void Shoot()
    {
        if (playerInventory.bulletCount > 0)
        {
            animator.SetTrigger("Shoot");
            audioSource.Play();
            GameObject prefab = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
            prefab.GetComponent<Bullet>().SetImpulse(Vector2.right, spriteRenderer.flipX ? -force * shootForce : force * shootForce, gameObject);
            playerInventory.bulletCount--;
        }
    }
    void CheckFall()
    {
        if ((Input.GetKeyDown(KeyCode.R) || transform.position.y < minimalHeight) && isCheatMode)
        {
            transform.position = playerSpawnPoint.transform.position;
            rigidbody.velocity = new Vector2(0, 0);
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
        {
            Destroy(gameObject);
        }
    }
}
