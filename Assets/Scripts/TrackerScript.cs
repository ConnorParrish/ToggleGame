using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrackerScript : MonoBehaviour {

	public Transform startBlock;
	public Transform endPoint;
	public Slider progBar;
    public float topDistance;

	// Use this for initialization
	void Start () {
		progBar.maxValue = endPoint.position.x - startBlock.position.x;
        topDistance = float.Parse(SaveScript.TMD.progress(Application.loadedLevelName));

	}
	
	// Update is called once per frame
	void Update () {
		progBar.value = transform.position.x;

        //If the top distance has been passed by the value/max value then save progress
        //Debug.Log(100*(progBar.value / progBar.maxValue) + "<" + topDistance);
        
        if(100*(progBar.value/progBar.maxValue) > topDistance)
        {
            float newTop = 100* (progBar.value / progBar.maxValue);
            int newTopInt = (int) newTop;
            //Debug.Log("New Max =" + newTopInt);
            SaveScript.TMD.saveProgress(newTopInt.ToString());
        }
	}
}
