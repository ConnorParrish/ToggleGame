using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float Speed;
	public float JumpStrength;
    private int CurrentLevelInt;
	public bool isGrounded = false;
	public bool isDead = false;
	public bool isWhite = true;
    public int bounceMag;
    public Transform endPoint;
    public Text CoinText;
    public bool reversed;

    public Camera playerCamera;


    //Animator to cause GameOver
    public Animator GameOver;

    // Creates the players Rigidbody2D for easy access
	Rigidbody2D rb2d;

	// Loads the animation call script
	private List<Animator> anim = new List<Animator>();
	private List<SpriteRenderer> spriteRend = new List<SpriteRenderer>();

    //Position variables to handle stopping == death
    Vector2 prevPosition;
    Vector2 bufferPosition;
    Vector2 currentPosition;


    // Use this for initialization
    void Start () {
		GetComponentsInChildren<Animator> (true, anim);
		GetComponentsInChildren<SpriteRenderer> (true, spriteRend);
		CurrentLevelInt = Application.loadedLevel;
        rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(Speed, 0);
        prevPosition = new Vector2(-1,-1);
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD

        //This code handles stop motion == death.
        currentPosition = transform.position;
        if(prevPosition == currentPosition)
        {
            //Debug.Log("Position code didn't work");
            //Debug.Log(prevPosition.ToString() + "==" + currentPosition.ToString());
            isDead = true;
        } else
        {            
            prevPosition = bufferPosition;
            bufferPosition = currentPosition;
        }



=======
		if (isDead){
			foreach (Animator anims in anim){
				anims.SetTrigger("isDead");
			}
		}
>>>>>>> dcc3dae5902aabcee99bd89ec4f6fa6897d63776
		// if the player reaches the end point of the level
		if (transform.position.x >= endPoint.position.x){
			rb2d.velocity = rb2d.velocity*(0); // Stops player movement
			Debug.Log("You've made it, you beautiful bastard");
            SceneManager.LoadScene("MainMenu");
            // anim.Stop();
        }
		else {
			// Keeps the velocity constant on each frame
			rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);

			// This is the kill-floor
			if (rb2d.position.y <= -10){
				isDead = true;
			}

			// Called on Death (from kill floor or debug 'D' key)
			if (isDead){
	            Debug.Log("Died");
				rb2d.velocity = rb2d.velocity*(0);

	            // This code added to trigger Gameover Anim.
	            GameOver.SetTrigger("isDead");
			}

			// Jumping
			if (Input.GetButtonDown("Jump") && isGrounded){
				rb2d.AddForce(Vector2.up * JumpStrength);
				isGrounded = false;
				foreach (Animator animator in anim){
					animator.SetBool ("isGrounded", isGrounded);
				}
			}

			// Code used to swap animations mid frame
			if (Input.GetKeyDown(KeyCode.Q)){

				 // Toggles the sprite renderers so the animations stay in sync
				foreach (SpriteRenderer sprites in spriteRend){
					sprites.enabled = !sprites.enabled;
				}			
			}
		}

		// Debug level reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(CurrentLevelInt);
        }


        // Debug death key
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDead = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }


    }

	void OnCollisionEnter2D(Collision2D blockCollision){
        // If the player hits a white or black platform, it affects the isGrounded condition for the animator
        if (blockCollision.gameObject.tag == "WhitePlatform" || blockCollision.gameObject.tag == "BlackPlatform"){
			isGrounded = true;

			foreach (Animator anims in anim){
				anims.SetBool ("isGrounded", isGrounded);
			}            
		}

		if (blockCollision.gameObject.tag == "Coin"){
			blockCollision.gameObject.SetActive(false);
			Debug.Log("We touched :O");
			int currentCoin = System.Convert.ToInt32(CoinText.text) + 1;
			CoinText.text = System.Convert.ToString(currentCoin);
		}

		// Kills the player on collision with spikes
		if (blockCollision.gameObject.tag == "Spike"){
			Debug.Log("Fuck, that hurt");
			isDead = true;
			// for (anims in anim){
			// 	anims.SetTrigger("isDead");
			// }
		}

        if (blockCollision.gameObject.tag == "Speed2x")
        {
            Speed = Speed * 2;
        }

        // Code to reverse player, works both directions from all directions.
        if (blockCollision.gameObject.tag == "Reverse")
        {
            Debug.Log("Reverse");
            reversed = !reversed;
            Speed = -Speed;
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y);

        }

        // Code for trampoline collision, hits player upward. 
        if (blockCollision.gameObject.tag == "Trampoline")
        {
            Debug.Log("Jumped");
            rb2d.AddForce(Vector2.up * bounceMag);
            isGrounded = false;
            foreach (Animator animator in anim)
            {
                animator.SetBool("isGrounded", isGrounded);
            }
        }
        //Code for reverse block
        
	}
}
