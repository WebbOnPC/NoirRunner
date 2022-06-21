using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public GameObject deathParticle;
    public GameObject player;



    public GameManager theGameManager;

    public float moveSpeed;

    bool facingRight; //Jumping, isGrounded, canDoubleJump; (probably not needed, may delete)
    public float speed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    public float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private Animator anim;
    private Rigidbody2D rb;
    public bool colliding;

    // jumpTime controls how long you hold/how high you jump. removed for now to try with just doubleJump
    //public float jumpTime;
    //private float jumpTimeCounter;

    //public float jumpHeight;
    [Range(1, 10)]
    public float jumpVelocity;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    //private bool doubleJumped;

        //for delayed start
    //private bool start = false;

    // Audio code
    AudioSource playerAS;
    public AudioClip playerJumpSound;
    AudioSource walkAudio;
    public AudioClip[] Walking;
    AudioSource landingAudio;
    public AudioClip LandingAudio;
    public float Volume;
    public bool alreadyPlayed = false;
    AudioSource wolfAudio;
    public AudioClip WolfAudio;

    //public GameObject blood;

    void Start()
    {
        GameManager theGameManager = gameObject.GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speedMilestoneCount = speedIncreaseMilestone;
        //	moveSpeedStore = moveSpeed;
        //	speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        //jumpTimeCounter = jumpTime;
        wolfAudio = GetComponent<AudioSource>();
        wolfAudio.PlayOneShot(WolfAudio, 0.2F);

        walkAudio = GetComponent<AudioSource>();
        playerAS = GetComponent<AudioSource>();
        landingAudio = GetComponent<AudioSource>();

        moveSpeed = 10;
    }
    
    void FixedUpdate()
    {
        if (grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround)) ;
    }

    //This is for a delayed start
    // Update is called once per frame
    /*public IEnumerator WaitForClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            wolfAudio.PlayOneShot(WolfAudio, 0.1F);
        }
    }*/

    void Update()
    {
      //  StartCoroutine(WaitForClick());

        // if (start = false)
        // {
        //moveSpeed = 10;
        MovePlayer(speed);
               // start = true;
            //    }
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;

            //moveSpeed = moveSpeed + speedMultiplier;
        }
        
        // Jump code WORKING FOR PC ONLY
        //Input.GetKeyDown(KeyCode.Space)
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // Double jump
        /*if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            //jumpTimeCounter = jumpTime;
            doubleJumped = true;
        }*/

        // Increase speed over time
        
        // Animations
        anim.SetFloat("Speed", rb.velocity.x);
        anim.SetBool ("Grounded", grounded);
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);

        if (grounded && !walkAudio.isPlaying)
            {
            // FOOTSTEPS - ARRAY
            walkAudio.clip = Walking[Random.Range(0, Walking.Length)];
            walkAudio.Play();
        }
    }

    public void Jump()
    {
        playerAS.PlayOneShot(playerJumpSound, 0.4F);
        alreadyPlayed = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killplayer")
        {
            Instantiate (deathParticle, player.transform.position, player.transform.rotation);          
            anim.SetInteger("State", 3);
            jumpVelocity = 0;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            moveSpeed = 0;
            //speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            walkAudio.volume = 0f;
            theGameManager.RestartGame();
        }
        alreadyPlayed = true;
    }

    void OnTriggerEnter2D()
    {
        // Landing Audio
        if (!alreadyPlayed)
        {
            landingAudio.PlayOneShot(LandingAudio, 1f);
            alreadyPlayed = true;
        }
    }
}