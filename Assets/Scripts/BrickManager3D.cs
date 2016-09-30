using UnityEngine;
using System.Collections;

public class BrickManager3D : MonoBehaviour {

	public GameObject[] WhitePlatforms;
	public GameObject[] BlackPlatforms;
	public GameObject Player;
	public string Active;
	public Color WhiteColor;
	public Color BlackColor;

	bool activeColor = false;

	// Use this for initialization
	void Start () {
		WhitePlatforms = GameObject.FindGameObjectsWithTag("WhitePlatform");
		BlackPlatforms = GameObject.FindGameObjectsWithTag("BlackPlatform");

		activatePlatforms(WhitePlatforms);
		activatePlatforms(BlackPlatforms);
	}

	// Used to turn activate the platforms correctly
	void activatePlatforms(GameObject[] platformSet){

		// For every platform in the array (White/Black)
		foreach (GameObject platform in platformSet){
			
			// If the platform has a BoxCollider component
			if (platform.GetComponent<BoxCollider>() != null){
				if (platform.tag == "WhitePlatform"){
					platform.GetComponent<BoxCollider>().enabled = true;
					platform.GetComponent<Renderer>().material.color = WhiteColor;			
				}
				else {
					platform.GetComponent<BoxCollider>().enabled = false;
					platform.GetComponent<Renderer>().material.color = BlackColor;
				}
			}
		}

		Active = "White";
	}

	// Used to swap from white/black states
	IEnumerator swapState(GameObject[] platformSet){
		foreach (GameObject platform in platformSet){
			if (platform.GetComponent<BoxCollider>() != null){

				// Enables/Disables the collider for the family of platforms
				platform.GetComponent<BoxCollider>().enabled = !platform.GetComponent<BoxCollider>().enabled;
			}
		}

		yield return new WaitForSeconds(.2f);

		
	}
	// Updates the public variable Active
	void updateColor(){
		activeColor = !activeColor;
			
		if (activeColor == false){
			Active = "White";
			Player.GetComponent<Renderer>().material.color = WhiteColor;
		}
		if (activeColor == true){
			Active = "Black";
			Player.GetComponent<Renderer>().material.color = BlackColor;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (Input.GetKeyDown(KeyCode.Q)){
			Debug.Log("Swapping colors");
			StartCoroutine(swapState(WhitePlatforms));
			StartCoroutine(swapState(BlackPlatforms));
			updateColor();
		}
	}
}
