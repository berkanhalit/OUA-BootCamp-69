using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float speed = 5f;
    //[HideInInspector] Gizliyebiliyor private etmek için
    private float movement;
    [SerializeField] //sadece alttakine etki eder(private seyleri inspectorda gorebilmemizi saglar)
    private float jumpSpeed = 10f;
    private Rigidbody2D rb2d;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    [SerializeField]
    private Animator playerAnimation;
    Vector3 velocity;
    public Vector3 respawnPoint;
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //sonradan yazilan ground degiskeni
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);


        movement = Input.GetAxis("Horizontal");

        //Zýplama buglu
        //velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        //transform.position += velocity * speed * Time.deltaTime;

        if (movement > 0)
        {

            rb2d.velocity = new Vector2(speed * movement, rb2d.velocity.y);
            transform.localScale = new Vector2(-5f, 5f);

        }
        else if (movement < 0)
        {
            rb2d.velocity = new Vector2(speed * movement, rb2d.velocity.y);
            transform.localScale = new Vector2(5f, 5f);
        }
        else
       {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
       }

        //if (Input.GetAxisRaw("Horizontal") == -1)
       // {
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
       // }
      //  else if (Input.GetAxisRaw("Horizontal") == 1)
      //  {
        //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      //  }

        //yukari asagi gitme scripti
        //movement = Input.GetAxis("Vertical");
        //if (movement > 0)
        //{
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, speed * movement);
        //}
        //else if (movement < 0)
        //{
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, speed * movement);
        //}

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);

        }

        PlayAndAnimate();

        }
        
          private void PlayAndAnimate()
        {
            playerAnimation.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

            playerAnimation.SetBool("OnGround", isTouchingGround);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "FallDetector")
            {
            gameManager.Respawn();
            }
            if (other.tag == "Chechpoint")
            {
            respawnPoint = other.transform.position;
            }
            if (other.tag == "Finish")
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (other.tag == "Finish2")
        {
            SceneManager.LoadScene(0);
        }

    }
}






