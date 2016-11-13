using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrackerScript : MonoBehaviour {

	public Transform startBlock;
	public Transform endPoint;
	public Slider progBar;

	// Use this for initialization
	void Start () {
		progBar.maxValue = endPoint.position.x - startBlock.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		progBar.value = transform.position.x;
	}
}
