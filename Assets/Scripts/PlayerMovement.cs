using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed;
	public bool isGrounded = true;
	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().material.color = Color.red;
		//GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D myRigidbody2D = GetComponent<Rigidbody2D>();
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, myRigidbody2D.velocity.y);

		if (Input.GetButtonDown("Jump") && isGrounded){
			//print("Jumping");
			myRigidbody2D.AddForce(Vector2.up * 150);
		}
	}

	void FixedUpdate(){
		// Rigidbody2D myRigidbody2D = GetComponent<Rigidbody2D>();
		
		// GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, myRigidbody2D.velocity.y);

		// if (Input.GetButtonDown("Jump") && isGrounded){
		// 	//print("Jumping");
		// 	myRigidbody2D.AddForce(Vector2.up * 150);
		// }
		//GetComponent<Rigidbody2D>().velocity = new Vector2 (Speed, 0);
	}
}
