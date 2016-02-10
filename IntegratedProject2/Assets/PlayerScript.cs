using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float maxMoveVelocity;
	public float moveForce;
	public float jumpForce;
	
	public Transform groundTransform;
	public float groundTransformRadius;
	public LayerMask groundMask;
	private bool isGrounded;

	private bool canDoubleJump;
	private bool facingLeft;

	// Use this for initialization
	void Start () {

		facingLeft = false;

	}
	
	void FixedUpdate(){

		//isGrounded = Physics2D.OverlapCircle (groundTransform.position, groundTransformRadius, groundMask);

		//if (facingLeft = true) {

			//gameObject.transform.rotation = Vector3 (transform.rotation.x, 180.0f, transform.rotation.z);

		//}

		//if (facingLeft = false) {

			//gameObject.transform.rotation = Vector3 (transform.rotation.x, 0.0f, transform.rotation.z);

		//}


	}
	
	// Update is called once per frame
	void Update () {

		if (isGrounded) {

			canDoubleJump = true;

		}
		
		// Check for A key being pressed, move left if true.
		if (Input.GetKey (KeyCode.A) && rigidbody2D.velocity.x < maxMoveVelocity){
			
			rigidbody2D.velocity = new Vector2(-moveForce, rigidbody2D.velocity.y);
			transform.Rotate(Vector3.forward * -90);
			
		}
		
		// Check for D key being pressed, move right if true.
		if(Input.GetKey (KeyCode.D) && rigidbody2D.velocity.x < maxMoveVelocity){
			
			rigidbody2D.velocity = new Vector2(moveForce, rigidbody2D.velocity.y);

		}

		if(Input.GetKeyDown(KeyCode.D)){

			facingLeft = false;

		}

		if(Input.GetKeyDown(KeyCode.A)){
			
			facingLeft = true;
				
		}

		
		// Check for Space key being pressed, set positive vertical velocity to jumpHeight.
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			Jump();
			
		}
		
	}
	
	void Jump()
	{
		if (isGrounded == true) {
			//set positive vertical velocity to jumpHeight
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
			
			isGrounded = false;
		} else if (!isGrounded && canDoubleJump) {
			//set positive vertical velocity to jumpHeight
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
			//rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpHeight);
			
			canDoubleJump = false;
		}
	}
	
	//void OnCollisionEnter (Collision hit)
	//{
	
	//onGround = true;
	//canDoubleJump = true;
	//Debug.Log("Colliding");
	
	//}
}
