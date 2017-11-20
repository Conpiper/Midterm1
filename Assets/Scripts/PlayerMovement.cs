using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Editor fields
    [SerializeField]
    private float speed = 8;

    [SerializeField]
    private float jumpHeight = 20;

    [SerializeField]
    private float groundCheckRadius = 0.35f;

    [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField]
    private LayerMask whatIsGround;
    #endregion

    #region private fields
    private bool isOnGround;
    private float horizontalInput;
    private Rigidbody2D myRigidbody2D;
    private bool pressedJump;
    private AudioSource audioSource;
    #endregion

    private void UpdateIsOnGround()
    {
        Collider2D[] groundColliders = Physics2D.OverlapCircleAll(groundCheckPosition.position, groundCheckRadius, whatIsGround);

        isOnGround = groundColliders.Length > 0;
    }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        UpdateIsOnGround();
        GetJumpInput();
        
    }

    private void GetJumpInput()
    {
        pressedJump = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
        HandleJump();
    }

    private void HandleJump()
    {
        if (pressedJump && isOnGround)
        {
            myRigidbody2D.velocity =
                new Vector2(myRigidbody2D.velocity.x, jumpHeight);

            audioSource.Play();

            isOnGround = false;
        }
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void HandlePlayerMovement()
    {
        myRigidbody2D.velocity =
            new Vector2(speed * horizontalInput, myRigidbody2D.velocity.y);
    }
    // Use this for initialization
    //the variables need to be assigned properly
    //I tried to do movement on my own, but ultimately i find that yours worked a lot better in the final build 
    /*public int Speed = 10;
    // the 10 is assigning it value
    public bool RightDirection = true;
    public int playerJumpHeight = 1000;
    private float moveX;
    public bool isGrounded;
    private Rigidbody2D myRigidBody2D;
    // the hope is to install acceleration tiles diagetically. 
    public Vector3 acceleration;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMove();
        
	}
    void PlayerMove()
    {
        //Controls will be touched on here, as well as direction, physics, and animation
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        if (moveX < 0.0f && RightDirection == false)
        
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && RightDirection == true)
        {
            FlipPlayer();
        }
        /*
         * if(moveX >! 0.1f && RightDirection =
         * 
         * 
         * 
         * 
         * 
         * 
         */

    //physics
    /*  gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * Speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
  }
  void Jump()
  {
      GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight);
      isGrounded = false;
  }
  void OnCollisionEnter2D(Collision2D col)
  {
      Debug.Log("Player has collided with " + col.collider.name);
      if (col.gameObject.tag == "ground")
      {
          isGrounded = true;
      }
    /*
      else if (col.gameObject.tag != "ground")
      {
          isGrounded = false;
      }
  }
 /* void FlipPlayer()
  {
      //for this part I reached out to the community of Unity to get help mirroring my player. They specifically told me about localScale and how it can be used.
      RightDirection = !RightDirection;
      Vector2 localScale = gameObject.transform.localScale;
      localScale.x *= -1;
      transform.localScale = localScale;
  }*/

}
