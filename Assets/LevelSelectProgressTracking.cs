using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LevelSelectProgressTracking : MonoBehaviour {

	public float currentProgress;
	public int coinCount;

	Transform progBar;
	SaveScript Saver;
	// Use this for initialization
	void Start () {
		progBar = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Level Select: " + SceneManager.GetActiveScene().buildIndex + " for Level :" + (SceneManager.GetActiveScene().buildIndex - 5));
		currentProgress = SaveScript.TMD.progress(SceneManager.GetActiveScene().buildIndex - 5);
		if (currentProgress == null){
			currentProgress = 0;
		}
		Debug.Log(currentProgress + " = " + currentProgress*100 + "%");
		progBar.localScale = new Vector3(currentProgress*100f*2.24f, progBar.localScale.y, progBar.localScale.z);		
	
	}
}
