using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{

    private UnityEngine.Vector3 respawnpoint;
    private bool isJumping;
    public MenuManager menuManager;
    public GameController gameController;
    public PlayerHealth playerHealth;
    public static int health;
    private Rigidbody2D rb;
    public AudioClip coinSound;
    public AudioClip chestSound;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public LayerMask enemyLayers;
    private Animator animator;
    private BoxCollider2D boxColl;    
    private float horizontal;
    private bool isFacingRight;

    [Header("Basic Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 6f;

    private float originalSpeed;

    [Header("Checks")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Transform spawnPoint;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();



    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("IsJumping", Mathf.Abs(rb.velocity.y));

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        rb.velocity = new UnityEngine.Vector2(horizontal * speed, rb.velocity.y);

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("IsAttacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); 
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player hit NPC Enemy");
            //enemy.GetComponent<enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isJumping = false;
            }
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            gameController.ChangeCoin(1);
            Destroy(other.gameObject);
            Debug.Log("Player has collected a coin!");
        }

        if (other.gameObject.tag == "Enemy")
        {
             Debug.Log("Player has hit Enemy");
             
            transform.position = respawnpoint;
        }
    

        if (other.gameObject.tag == "Checkpoint")
        {
            respawnpoint = transform.position;
        }

        if (other.gameObject.tag == "mapEdge")
        {
             Debug.Log("Player has hit the map Edge");
           
           transform.position = respawnpoint;
            
        }

    }

    


    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            UnityEngine.Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }    
}
