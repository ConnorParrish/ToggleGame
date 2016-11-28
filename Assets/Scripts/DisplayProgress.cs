using UnityEngine;
using System.Collections;

public class DisplayProgress : MonoBehaviour {

    public string LevelToShow;
    public string showing;
    public TextMesh displayText;

	// Use this for initialization
	void Start () {	    
	}
	
	// Update is called once per frame
	void Update () {
        showing = SaveScript.TMD.progress(LevelToShow);
        //Debug.Log(showing);
        displayText.text = showing + "/100";
	}
}
