using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerViaTouch : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            // Refers to the first finger on screen
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            if (touchPosition.x > 1) {
                //move down
                rb.velocity = new Vector2(0, -moveSpeed);
            } else if (touchPosition.x < -1) {
                //move up
                rb.velocity = new Vector2(0, moveSpeed);
            }
        } else {
            //no movement when no finger presses are detected
            rb.velocity = new Vector2(0, 0);
        }
    }
}
