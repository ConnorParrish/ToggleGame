using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject Player;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(3, 0, -10);
		//GameObject.transform.x 
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position + offset;
	}
}
