using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysics : MonoBehaviour
{

	//[SerializeField] private BoxCollider2D boxCollider2d;
	//[SerializeField] private PlatformEffector2D pe;
	public int playerLayer, platformLayer;
	//private bool jumpOffCoroutineIsRunning = false;
	public GameObject player;
    //public RectTransform playerRt;
    public double playerBottomPosition;
    public double distance;
    public double yPosition;
	public bool dropping;
    public bool preventDrop;
    private bool returnInfo;
    private Bounds boxBounds;
    private Bounds playerBounds;
    private float top;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerBottomPosition = player.GetComponent<BoxCollider2D>().offset.y - 0.4 * player.GetComponent<BoxCollider2D>().size.y;
        //Debug.Log("player.transform.position.y = " + player.transform.position.y);
        //Debug.Log("playerBottomPosition = " + playerBottomPosition);
        playerLayer = LayerMask.NameToLayer("Player");
		platformLayer = LayerMask.NameToLayer("Platform");
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
        yPosition = player.GetComponent<BoxCollider2D>().offset.y - 0.4 * player.GetComponent<BoxCollider2D>().size.y;
        dropping = false;
        preventDrop = false;
        returnInfo = true;
        boxBounds = GetComponent<BoxCollider2D>().bounds;
        playerBounds = player.GetComponent<BoxCollider2D>().bounds;
        top = boxBounds.center.y + boxBounds.extents.y;
        playerBottomPosition = playerBounds.center.y - playerBounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        boxBounds = GetComponent<BoxCollider2D>().bounds;
        playerBounds = player.GetComponent<BoxCollider2D>().bounds;
        top = boxBounds.center.y + boxBounds.extents.y;
        playerBottomPosition = playerBounds.center.y - playerBounds.extents.y;        
        //playerBottomPosition = player.transform.position.y - 0.5 * player.GetComponent<SpriteRenderer>().bounds.size.y;
        //yPosition = transform.position.y;
        
        yPosition = top;
        distance = playerBottomPosition - yPosition;
        /*if (returnInfo = true) {
            StartCoroutine(Info());
        }*/
        if(Input.GetKeyDown(KeyCode.DownArrow) && distance < 1 && distance > 0 /*&& isGrounded == true*/) {
            /*Debug.Log("transform.position.y = " + transform.position.y);
            Debug.Log("player.transform.position.y = " + player.transform.position.y);
            Debug.Log("playerBottomPosition = " + playerBottomPosition);*/
            StartCoroutine(Drop());
            //prioritize dropping over other ifs
        } else if (dropping) {
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
            //Debug.Log("IgnoreLayerCollision = false");
            //every platform is droppable when dropping is true
        } else if (distance > 1) {
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
            //Debug.Log("IgnoreLayerCollision = true");
            //by default the platforms below can't be dropped unless the down button is pressed
        } else {
            if (player.GetComponent<Rigidbody2D>().velocity.y < -1) {
                Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
                preventDrop = true;
                //Game is wonky, thie prevents random drops
            } else {
                if (!preventDrop) {
                    Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
                    //If dropping isn't true AND it isn't below the char, it means it's above (duh). They can be jumped through.
                }
            }
        }
        if (player.GetComponent<Rigidbody2D>().velocity.y > 0) {
            preventDrop = false;
        }
    }
    IEnumerator Drop() {
        dropping = true;
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
        Debug.Log("IgnoreLayerCollision = true");
        yield return new WaitForSeconds (0.3f);
        dropping = false;
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
    }

    IEnumerator Info() {
        returnInfo = false;
        yield return new WaitForSeconds (2f);
        Debug.Log("transform.position.y = " + transform.position.y);
        Debug.Log("player.transform.position.y = " + player.transform.position.y);
        Debug.Log("playerBottomPosition = " + playerBottomPosition);
        returnInfo = true;
    }
}
