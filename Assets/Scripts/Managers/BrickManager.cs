using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickManager : MonoBehaviour {

	public GameObject[] WhitePlatforms;
	public GameObject[] BlackPlatforms;
	public string Active;
	public Color WhiteColor;
	public Color BlackColor;
	public Sprite WhiteSprite;
	public Sprite BlackSprite;
	
	// Use this for initialization
	void Start () {
		//DONT NEED IT
		// Debug.Log("Finding objects tagged WhitePlatform...");

		WhitePlatforms = GameObject.FindGameObjectsWithTag("WhitePlatform");
		BlackPlatforms = GameObject.FindGameObjectsWithTag("BlackPlatform");

		foreach (GameObject platform in WhitePlatforms){
			//platform.GetComponent<SpriteRenderer>().sprite = WhiteSprite;
			if (platform.GetComponent<BoxCollider2D>() != null){
				platform.GetComponent<BoxCollider2D>().enabled = true;
			}
		}

		foreach (GameObject platform in BlackPlatforms){
			//platform.GetComponent<SpriteRenderer>().sprite = BlackSprite;
			if (platform.GetComponent<BoxCollider2D>() != null){
				platform.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}

	void swapState(GameObject[] platformSet){
		foreach (GameObject platform in platformSet){
			if (platform.GetComponent<BoxCollider2D>() != null){
				platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
			}
		}
	}
	
	IEnumerator waitpls(){
		yield return new WaitForSeconds(.2f);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q) || ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && Input.touches[0].position.x > Screen.width/2)){
			swapState(WhitePlatforms);
			swapState(BlackPlatforms);
			StartCoroutine(waitpls());
		}
	}
}
