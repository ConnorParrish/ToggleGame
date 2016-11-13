using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrackerScript : MonoBehaviour {

	public Transform startBlock;
	public Transform endBlock;
	public Slider progBar;

	// Use this for initialization
	void Start () {
		Debug.Log(startBlock.position);
		Debug.Log(endBlock.position);

		progBar.maxValue = endBlock.position.x - startBlock.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		progBar.value = transform.position.x;
	}
}
