using UnityEngine;
using System.Collections;

public class PlayerMovement3D : MonoBehaviour {

	public float Speed;
	public bool isGrounded = true; //enable to test while jump is being fixed

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(Speed, 0);
	}
	
	// Determines if the player can jump
	// void OnCollisionEnter(Collision blockCollision){
	// 	return;
	// }

	// Update is called once per frame
	void Update () {
		Rigidbody rb3d = GetComponent<Rigidbody>();

		if (Input.GetButtonDown("Jump") && isGrounded){
			Debug.Log("I jump");
			rb3d.AddForce(Vector3.up * 300);
		}


	}
}
