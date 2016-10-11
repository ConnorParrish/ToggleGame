using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed;
	public float JumpStrength;
	public bool isGrounded = false;
	public bool isDead = false;

	Rigidbody2D rb2d;
	Material playerMat;

	// Use this for initialization
	void Start () {
		playerMat = GetComponent<Renderer>().material;
		rb2d = GetComponent<Rigidbody2D>();

		playerMat.color = Color.red;
		rb2d.velocity = new Vector2(Speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);

		if (isDead){
			rb2d.velocity = rb2d.velocity*(-1);
		}

		if (Input.GetButtonDown("Jump") && isGrounded){
			//print("Jumping");
			rb2d.AddForce(Vector2.up * JumpStrength);
			isGrounded = false;
		}

		if (Input.GetKeyDown(KeyCode.Q)){
			if (playerMat.color == Color.red) {
				playerMat.color = Color.black;
			}
			else if (playerMat.color == Color.black) {
				playerMat.color = Color.red;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D blockCollision){
		//Debug.Log("blockCollision.gameObject.tag = " + blockCollision.gameObject.tag);
		if (blockCollision.gameObject.tag == "WhitePlatform" || blockCollision.gameObject.tag == "BlackPlatform"){
			isGrounded = true;
		}
		if (blockCollision.gameObject.tag == "Spike"){
			Debug.Log("Fuck, that hurt");
			isDead = true;
		}
	}
}
