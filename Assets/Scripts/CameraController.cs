using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject Player;
	PlayerMovement playerMovement;

	private Vector3 offset;
	private Vector3 reversedOffset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(3, 0, -10);
		reversedOffset = new Vector3(-3,0,-10);
		playerMovement = Player.GetComponent<PlayerMovement>();
		//GameObject.transform.x 
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerMovement.reversed){
			transform.position = playerMovement.transform.position + offset;		
		} else if (playerMovement.reversed){
			Debug.Log("woah it worked");
			transform.position = playerMovement.transform.position + reversedOffset;
		}
	}
}
