using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float onGroundCircle = 0.2f;
    public LayerMask groundLayer;
    public Transform onGround;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            Debug.Log("Jump input detected");
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));

        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0) fireRocket();

    }

    void FixedUpdate()
    {
        //check if grounded, if not then falling
        grounded = Physics2D.OverlapCircle(onGround.position, onGroundCircle, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("vSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y);

        if(move> 0 && !facingRight)
        {
            flip();
        }
        else if (move< 0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight=!facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void fireRocket()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else if(!facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

    public void UpdateJumpHeight(float newJumpHeight)
    {
        jumpHeight += newJumpHeight;
    }

    public void UpdateSpeed(float newSpeed)
    {
        maxSpeed += newSpeed;
    }

}
