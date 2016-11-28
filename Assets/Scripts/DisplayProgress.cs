using UnityEngine;
using System.Collections;

public class DisplayProgress : MonoBehaviour {

    public string LevelToShow;
    public string showing;
    public TextMesh displayText;
    public bool isCoins;

	// Use this for initialization
	void Start () {	    
	}
	
	// Update is called once per frame
	void Update () {
        if (isCoins)
        {
            showing = SaveScript.TMD.coinProgress(LevelToShow).ToString();
            displayText.text = showing + "/3";
        } else
        {
            showing = SaveScript.TMD.progress(LevelToShow);
            displayText.text = showing + "/100";
        }

        //Debug.Log(showing);

	}
}
