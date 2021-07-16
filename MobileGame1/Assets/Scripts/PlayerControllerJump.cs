using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float speed;
    public float jumpForce;

    //private bool isGrounded;
    //public Transform groundCheck;
    //public float checkRadius;
    //public LayerMask whatIsGround;

    //totalJumps will later be a private int and be determined by a character ID, obtained from a script dealing w/ IDs
    public int totalJumps;
    private int currentJumps;
    //bool jumpOffCoroutineIsRunning = false;
    bool stopExit = true;
    int playerLayer, platformLayer;
    bool control1 = true;
    bool control2 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
		platformLayer = LayerMask.NameToLayer("Platform");
        currentJumps = totalJumps;
        //Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(Input.GetKeyDown(KeyCode.UpArrow) && currentJumps >= 1) {
            rb.velocity = Vector2.up * jumpForce;
            //currentJumps--;
            //Debug.Log("Starting JumpOff");
			//Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
            //Debug.Log("IgnoreLayerCollision = true");
            //stopExit = false;
            //Debug.Log("stopExit = " + stopExit);
            //StartCoroutine(Exit());
        } else if (Input.GetKeyDown(KeyCode.DownArrow) /*&& !jumpOffCoroutineIsRunning*/) {
            //Debug.Log("Starting JumpOff");
			//Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
            //Debug.Log("IgnoreLayerCollision = true");
            //stopExit = false;
            //Debug.Log("stopExit = " + stopExit);
            //StartCoroutine(Exit());
		}
        /*if(isGrounded) {
            //This is just the "easy" version; later a jump recharge will be implemented
            currentJumps = totalJumps;
        }*/
        /*if (rb.velocity.y > 0) {
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
        } else if (rb.velocity.y <= 0 && !jumpOffCoroutineIsRunning) {
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
        }*/
    }

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (0, rb.velocity.y);
	}

    /*IEnumerator JumpOff()
    {
        jumpOffCoroutineIsRunning = true;
        Debug.Log("JumpOff Started");
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
        yield return new WaitForSeconds (0.3f);
        stopExit = false;
    }*/
    void OnTriggerEnter2D(Collider2D other){
        //making no "bounce" happen
        //rb.velocity = Vector2.up*0;
        currentJumps = totalJumps;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        /*Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
        Debug.Log("IgnoreLayerCollision = false");
        StartCoroutine(Exit());*/
    }

    //In settings player can decide which button they want to jump and drop, default is
    //right button jump and left button drop (control1) inverse = control2
    public void OnClickControl1()
    {
        control1 = true;
        control2 = false;
        ButtonConfiguration(control1);
    }

    public void OnClickControl2()
    {
        control1 = false;
        control2 = true;
        ButtonConfiguration(control1);
    }

    //need to edit this
    void ButtonConfiguration(bool control1)
    {
        /*
        if(control1 == true)
        {
            rightButton = jump;
            leftButton = drop;
        }
        else
        {
            rightButton = drop;
            leftButton = jump;
        }
        */
    }

    /*IEnumerator Exit() {
        yield return new WaitForSeconds (0.3f);
        if(stopExit = false) {
            yield return new WaitForSeconds(0.3f);
            Debug.Log("On exit function called for PlayerControllerJump");
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
            stopExit = true;
            Debug.Log("stopExit = " + stopExit);
        }
    }*/
}