using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed;
	public float JumpStrength;
	public bool isGrounded = true;
	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().material.color = Color.red;
		//GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, rb2d.velocity.y);

		if (Input.GetButtonDown("Jump") && isGrounded){
			//print("Jumping");
			rb2d.AddForce(Vector2.up * JumpStrength);
			isGrounded = false;
		}		
	}

	void OnCollision(Collision blockCollision){
		Debug.Log("blockCollision.gameObject.tag = " + blockCollision.gameObject.tag);
		if (blockCollision.gameObject.tag == "WhitePlatform" || blockCollision.gameObject.tag == "BlackPlatform"){
			isGrounded = true;
		}
	}
}
