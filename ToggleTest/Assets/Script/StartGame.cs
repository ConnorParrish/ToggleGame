using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class StartGame : MonoBehaviour {

    public string LevelToLoad;
    public bool isExit;

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {

        //If this 'button' is a quit button.
        if (isExit)
        {
            Debug.Log("Quit Working");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(LevelToLoad);
        }



    }


    // Update is called once per frame
    void Update () {
	    
	}
}
