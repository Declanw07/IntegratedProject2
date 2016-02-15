using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	// Movement based Initializations

	public float maxMoveVelocity;
	public float moveForce;
	public float jumpForce;

	// Double Jump related Initializations

	public Transform groundTransform;
	//public List<Transform> groundTransform;
	public float groundTransformRadius;
	public LayerMask groundMask;
	public bool isGrounded;

	private bool canDoubleJump;

	// Game Logic related Initializations

	public GameObject respawnPoint;
	public int deathCount;
	public GameObject dictatorObject;
	public GameObject crown;
	public float dictatorTime;
	public bool isDictator = false;
	public float dictatorTimeToWin;
	private bool hasWon = false;

	// Player Input Variable Initializations

	public string LeftJoystick;		// Assigned in the Unity Editor, *Note: In Editor assign as LeftJoystickX_Px where "x" is the player number.
	public string RightJoystick;	// Assigned in the Unity Editor, *Note: In Editor assign as RightJoystickX_Px where "x" is the player number.
	public string A_Button;			// Assigned in the Unity Editor, *Note: In Editor assign as AButton_Px where "x" is the player number.
	public string B_Button;			// Assigned in the Unity Editor, *Note: In Editor assign as BButton_Px where "x" is the player number.
	public string X_Button;			// Assigned in the Unity Editor, *Note: In Editor assign as XButton_Px where "x" is the player number.
	public string Y_Button;			// Assigned in the Unity Editor, *Note: In Editor assign as YButton_Px where "x" is the player number.
	private float horizontalAxis;	// This value is the float value of the Controller's X-axis Joystick movement on the left stick.
	

	// Use this for initialization
	void Start () {

	}
	
	void FixedUpdate(){

		isGrounded = Physics2D.OverlapCircle (groundTransform.position, groundTransformRadius, groundMask);

	}
	
	// Update is called once per frame
	void Update () {

		horizontalAxis = Input.GetAxis(LeftJoystick);

		if (isDictator) {

			dictatorTime += Time.deltaTime;

			if(dictatorTime == dictatorTimeToWin){

				hasWon = true;

			}

		}

		if (isGrounded) {

			canDoubleJump = true;

		}

		// Check if the Joystick movement multiplied by the current X-axis velocity is less than maximum allowed velocity.
		if(horizontalAxis * rigidbody2D.velocity.x < maxMoveVelocity)
		{
			// Add Horizontal force to the player object equal to the player's current joystick movement multiplied by the moveForce assigned in Editor.
			rigidbody2D.AddForce(Vector2.right * horizontalAxis * moveForce);
		}

		// Check if the absolute value of the Player's velocity is greater than the maximum allowed velocity.
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxMoveVelocity)
		{
			// Set the Player's velocity equal to the maximum allowed velocity of the correct sign and conserve y axis velocity.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxMoveVelocity, rigidbody2D.velocity.y);
		}


		//////////////////////////////////////////////////////
		/// Below is legacy horizontal movement code no longer
		/// needed but left in-case of version mismatch or
		/// issues later on not apparent at the moment.
		//////////////////////////////////////////////////////


		// Check for A key being pressed, move left if true.
		//if (Input.GetKey (KeyCode.A) && rigidbody2D.velocity.x < maxMoveVelocity){

			//rigidbody2D.velocity = new Vector2(moveForce * horizontalAxis, rigidbody2D.velocity.y);
			
		//}
		
		// Check for D key being pressed, move right if true.
		//if(Input.GetAxis(LeftJoystick) && rigidbody2D.velocity.x < maxMoveVelocity){
			
			//rigidbody2D.velocity = new Vector2(moveForce * horizontalAxis, rigidbody2D.velocity.y);

		//}

		//if(Input.GetKeyDown(KeyCode.D)){



		//}

		//if(Input.GetKeyDown(KeyCode.A)){
			

				
		//}

		
		// Check for the current player's controller's assigned a button being pressed, then call the Jump() method.
		if (Input.GetButtonDown (A_Button)) {
			
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

	///////////////////////////////////////////////////
	/// Legacy code for old double jump system, it's
	/// complete garbage but left in-case a need to
	/// revert back arises.
	///////////////////////////////////////////////////
	
	//void OnCollisionEnter (Collision hit)
	//{
	
	//onGround = true;
	//canDoubleJump = true;
	//Debug.Log("Colliding");
	
	//}
		
	// Enter Trigger method, used to detect when an object enters any trigger on scene.
	void OnTriggerEnter2D (Collider2D col)
	{
		// If the player enters the aptly named "Killbox" trigger...
		if(col.gameObject.name == "Killbox"){

			// Log this in the console.
			Debug.Log(gameObject.name + " Died");

			// Set the player's position to a respawn point, this will later be revamped.
			gameObject.transform.position = respawnPoint.transform.position;

			// Iterate upon the player's death count.
			deathCount++;

		}
		// If the player enters a trigger with name "Dictatorship"...
		if (col.gameObject.name == "Dictatorship") {

			// Log this in the console.
			Debug.Log ("Dictator Status Gained");

			// Set dictatorship status to true.
			isDictator = true;
			// Set the hidden crown as active.
			crown.SetActive(true);
			// Destroy the dictator object (The crown used to gain dictatorship status)
			Destroy(dictatorObject);

		}


	}

}
