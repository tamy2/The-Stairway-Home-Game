using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller2 : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float height;
    private float width;
    private float scrollSpeedY = -1f;
    private float scrollSpeedX = -2f;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = 17.7f;
        collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeedX, scrollSpeedY);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width) {
            Vector2 resetPositionX = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPositionX;
        }
    }
}
