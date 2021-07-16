using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayPlatform : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private BoxCollider2D boxCollider2d;
	[SerializeField] private PlatformEffector2D pe;
	public int playerLayer, platformLayer;
	//private bool jumpOffCoroutineIsRunning = false;
	public GameObject Connie;
	public bool fallThrough = false;

	
	// Use this for initialization
	void Start () {
		rb = Connie.transform.GetComponent<Rigidbody2D>();
		boxCollider2d = Connie.transform.GetComponent<BoxCollider2D>();
		pe = transform.GetComponent<PlatformEffector2D>();
		playerLayer = LayerMask.NameToLayer("Char");
		platformLayer = LayerMask.NameToLayer("Platform");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded()) {
			//StartCoroutine("JumpOff");
			pe.rotationalOffset += 180;
			fallThrough = true;
		}

		else if (Input.GetKey(KeyCode.UpArrow) && isGrounded()) {
			//StartCoroutine("JumpOff");
			pe.rotationalOffset += 180;
			fallThrough = true;
		}

		//if (rb.velocity.y > 0 && !jumpOffCoroutineIsRunning)
			//Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		
		//else if (rb.velocity.y <= 0 && !jumpOffCoroutineIsRunning)
			//Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);		
	}

	public bool isGrounded() {
		float extraHeightText = 1f;
		RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, platformLayer);
		return raycastHit != null;
	}

	IEnumerator JumpOff() {
		//jumpOffCoroutineIsRunning = true;
		//Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		yield return new WaitForSeconds (0.5f);
		//Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
		//jumpOffCoroutineIsRunning = false;
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		/*Debug.Log("fallthrough = " + fallThrough);
		if (collision.gameObject.CompareTag("Player"))
		{
			pe.rotationalOffset += 180;
			JumpOff();
		}*/
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("On exit function called");
		fallThrough = false;
		pe.rotationalOffset += 180;
	}
}