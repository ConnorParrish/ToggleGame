using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public GameObject Player;
    public bool isDead;


	// Use this for initialization
	void Start () {

        private GameObject PlayerScript = Player.GetComponent(PlayerMovement);
}
	
	// Update is called once per frame
	void Update () {
        if (Player.GetComponent(PlayerMovement) == true)
        {
            isDead = true;
        }
	
	}
}
