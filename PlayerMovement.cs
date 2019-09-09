using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed;
    public float jumpForce;
    public float dashForce;
    private float moveInput;
  

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groudCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    private bool activeDash;
    private float dashTime;
    public float startDashTime;
    private int direction;

    //dash doesnt work yet for some reason

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        speed = 7f;
        activeDash = true;
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapCircle(groudCheck.position, checkRadius, whatIsGround);
        if (isGrounded == true)
        {
            activeDash = true;
        }

        moveInput = Input.GetAxis("Horizontal");
       


        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);


        if (facingRight == true)
        {
            direction = 0;
        }
        else if (facingRight == false)
        {
            direction = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            speed = 14f;
        }
        else
        {
            speed = 7f;
        }
        if (facingRight == false && moveInput > 0)
        {
            FacingFlip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            FacingFlip();
        }


        //AirDash Ability code

        if (Input.GetKeyDown(KeyCode.LeftShift) && activeDash == true && isGrounded == false)
        {
            
           

            if (direction == 0)
            {
                
                rb.velocity = Vector2.right * dashForce;
               
                
                activeDash = false;
            }
            else if (direction == 1)
            {
                
                rb.velocity = Vector2.left * dashForce;
                
                activeDash = false;
            }
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = 1;
            activeDash = true;
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

      
    }

    //Flip in the direction that th player is facing
   private void FacingFlip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


 
}
