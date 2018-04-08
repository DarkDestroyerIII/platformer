using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int jumpLimit;
	private float jumpVelocity;
	private int jumpAmount = 0;

	bool jump = false;
	float horizontalMovement = 0.0f;

	public float jumpHeight;

	// Use this for initialization
	void Start () {
		jumpVelocity = calculateJumpVelocity (jumpHeight);
	}

	// Update is called once per frame
	void Update () {

		

//		Vector3 position = transform.position;
//
//
//		position.x += Input.GetAxis("Horizontal") * Time.deltaTime;
//
//
//		position.y += Input.GetAxis("Vertical")*100 * Time.deltaTime;
//
//		transform.position = position;
//
//
//

		

		horizontalMovement = Input.GetAxis("Horizontal");

//		velocity.y = 5 * Input.GetAxis("Vertical");

		if (Input.GetButtonDown ("Jump") && !jump) {
			jump = true;
		}

		

//		Debug.Log (jumpAmount);
//		Debug.Log(rigidbody2D.velocity);





	}

	void FixedUpdate(){

		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
        Vector2 velocity = rigidbody2D.velocity;

		RaycastHit2D groundHit = Physics2D.Raycast(transform.Find("GroundChecker").position, Vector2.down, 0.1f);


		if (groundHit) {
			
			Debug.Log("GROUND");
			jumpAmount = 0;

		}

		// Debug.Log(transform.Find("RightWallChecker"));

		RaycastHit2D rightwallHit = Physics2D.Raycast(transform.Find("RightWallChecker").position, Vector2.right, 0.1f);


		if (rightwallHit) {
			
			jumpAmount = 0;

		}


		RaycastHit2D leftwallHit = Physics2D.Raycast(transform.Find("LeftWallChecker").position, Vector2.left, 0.1f);


		if (leftwallHit) {
			
			jumpAmount = 0;

		}
		velocity.x = 5 * horizontalMovement;

		if(jump) {
			jump = false;
			if (jumpAmount < jumpLimit) {
				jumpAmount += 1;
				velocity.y = jumpVelocity;
			}
		}

		

        rigidbody2D.velocity = velocity;

	}

	float calculateJumpVelocity (float height) {
		return Mathf.Sqrt (2 * Mathf.Abs(Physics2D.gravity.y * GetComponent<Rigidbody2D>().gravityScale) * height);
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag("Spike")) {
			Debug.Log (collision.gameObject.name);

			GameObject.FindWithTag ("GameController").GetComponent<GameController> ().ReloadScene ();

			Destroy (gameObject);
		}
	}

}
