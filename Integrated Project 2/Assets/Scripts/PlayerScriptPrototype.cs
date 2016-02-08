using UnityEngine;
using System.Collections;

public class PlayerScriptPrototype : MonoBehaviour {

	public float moveVelocity;
	public float jumpHeight;
	
	private bool onGround;
	private bool canDoubleJump;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){

	}
	
	// Update is called once per frame
	void Update () {
	
		// Check for A key being pressed, move left if true, set Z velocity to 0.0f
		if (Input.GetKey (KeyCode.A)){

			rigidbody.velocity = new Vector3(-moveVelocity, rigidbody.velocity.y);

		}

		// Check for D key being pressed, move right if true, set Z velocity to 0.0f
		if(Input.GetKey (KeyCode.D)){

			rigidbody.velocity = new Vector2(moveVelocity, rigidbody.velocity.y);

		}

		// Check for Space key being pressed, set positive vertical velocity to jumpHeight, set Z velocity to 0.0f
		if (Input.GetKeyDown (KeyCode.Space)) {

			Jump();

		}

	}

	void Jump()
	{
		if (onGround == true) {
			//set positive vertical velocity to jumpHeight, set Z velocity to 0.0f
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpHeight);

			onGround = false;
		} else if (!onGround && canDoubleJump) {
			//set positive vertical velocity to jumpHeight, set Z velocity to 0.0f
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpHeight);

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
