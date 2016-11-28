using UnityEngine;
using System.Collections;

public class DeathCounter : MonoBehaviour {

    public TextMesh TM;
	// Use this for initialization
	void Start () {

        if(SaveScript.TMD != null)
        {
            string num = SaveScript.TMD.noOfDeath.ToString();
            //Debug.Log("TextMesh: " + num);
            TM.text = SaveScript.TMD.noOfDeath.ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(SaveScript.TMD + " This shouldn't be null");
        if (SaveScript.TMD != null)
        {
            string num = SaveScript.TMD.noOfDeath.ToString();
            //Debug.Log("TextMesh: " + num);
            TM.text = SaveScript.TMD.noOfDeath.ToString() + " Deaths";
        }
    }
}
