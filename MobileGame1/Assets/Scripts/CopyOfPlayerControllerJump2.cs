using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJump2 : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float speed;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
}
