using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string LevelToLoad;
    public bool IsExit;
	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Button Working");
        if (IsExit)
        {
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
