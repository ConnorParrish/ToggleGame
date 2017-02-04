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
	public GameObject FirstPlatform;
    public GameObject whitePlayer;
    public GameObject blackPlayer;

	void Awake() {
        whitePlayer = GameObject.Find("Player_2D").transform.GetChild(0).gameObject;
        blackPlayer = GameObject.Find("Player_2D").transform.GetChild(1).gameObject;

		FirstPlatform = GameObject.FindGameObjectWithTag("WhitePlatform");
	}
	// Use this for initialization
	void Start () {
		//DONT NEED IT
		// Debug.Log("Finding objects tagged WhitePlatform...");

	}

	void swapState(GameObject[] platformSet){
		if (whitePlayer.activeSelf)
        {
            whitePlayer.SetActive(false);
            blackPlayer.SetActive(true);
        }
        else
        {
            whitePlayer.SetActive(true);
            blackPlayer.SetActive(false);
        }
	}
	
	IEnumerator waitpls(){
		yield return new WaitForSeconds(.2f);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q) || ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && Input.touches[0].position.x > Screen.width/2)){
			swapState(WhitePlatforms);
			StartCoroutine(waitpls());
		}
	}
}
