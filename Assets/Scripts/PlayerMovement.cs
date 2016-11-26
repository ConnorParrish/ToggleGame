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
	public bool confetti = false;
    public int bounceMag;
    public Transform endPoint;
    public Text CoinText;
    public bool reversed;
    public bool soundHooks;
    public GameObject endConfetti;

    public AudioSource soundEffectSource;

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

    IEnumerator LongJump()
    {
        float prevSpeed = Speed;

        Speed = Speed * 2;
        while (!isGrounded) {
            yield return null;
        }

        Debug.Log("Jack Shit");

        Speed = prevSpeed;
    }

    // Update is called once per frame
    void Update () {
		if (isDead){
			foreach (Animator anims in anim){
				anims.SetTrigger("isDead");
			}
		}
		// if the player reaches the end point of the level
		if (transform.position.x >= endPoint.position.x){
			if (soundHooks){
				soundEffectSource.Play();
			}
			rb2d.velocity = rb2d.velocity*(0); // Stops player movement
			Debug.Log("You've made it, you beautiful bastard");
			endConfetti.SetActive(true);
            // SceneManager.LoadScene("MainMenu");
            // anim.Stop();
        }
		else {
			// Keeps the velocity constant on each frame
			rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);

			// This is the kill-floor
			if (rb2d.position.y <= -10){
				if (soundHooks){
					soundEffectSource.Play();
				}
				isDead = true;
			}

			// Called on Death (from kill floor or debug 'D' key)
			if (isDead){
	            Debug.Log("Died");
				rb2d.velocity = rb2d.velocity*(0);

	            // This code added to trigger Gameover Anim.
	            GameOver.SetTrigger("isDead");
			}

			// Jumping (if tapped on the left side of the screen)
			if ((Input.GetButtonDown("Jump") || ((Input.touchCount == 1) && Input.touches[0].position.x < Screen.width/2)) && isGrounded){
				if (soundHooks){
					soundEffectSource.Play();
				}
				rb2d.AddForce(Vector2.up * JumpStrength);
				isGrounded = false;
				foreach (Animator animator in anim){
					animator.SetBool ("isGrounded", isGrounded);
				}
			}

			// Code used to swap animations mid frame (if tapped on the right side of the screen)
			if (Input.GetKeyDown(KeyCode.Q) || ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && Input.touches[0].position.x > Screen.width/2)){
				if (soundHooks){
					soundEffectSource.Play();
				}

				isWhite = !isWhite;
				 // Toggles the sprite renderers so the animations stay in sync
				foreach (SpriteRenderer sprites in spriteRend){
					sprites.enabled = !sprites.enabled;
				}			
			}
		}

		// Debug level reset (if tapped on the bottom half of the screen while dead)
        if (Input.GetKeyDown(KeyCode.R) || ((Input.touchCount == 1) && Input.touches[0].position.y < Screen.height/2) && isDead)
        {
			if (soundHooks){
				soundEffectSource.Play();
			}
            SceneManager.LoadScene(CurrentLevelInt);
        }


        // Debug death key
        if (Input.GetKeyDown(KeyCode.D))
        {
        	if (soundHooks){
				soundEffectSource.Play();
			}
            isDead = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
        	if (soundHooks){
				soundEffectSource.Play();
			}
            SceneManager.LoadScene("MainMenu");
        }


    }

    void OnTriggerEnter2D(Collider2D col){
    	Debug.Log("We touched :O");
		int currentCoin = System.Convert.ToInt32(CoinText.text) + 1;
		CoinText.text = System.Convert.ToString(currentCoin);
		col.gameObject.SetActive(false);
    }

	void OnCollisionEnter2D(Collision2D blockCollision){
        // If the player hits a white or black platform, it affects the isGrounded condition for the animator
        if ((blockCollision.gameObject.tag == "WhitePlatform" && isWhite) || (blockCollision.gameObject.tag == "BlackPlatform" && !isWhite)){
			// if (soundHooks){
			// 	soundEffectSource.Play();
			// }

			isGrounded = true;

			foreach (Animator anims in anim){
				anims.SetBool ("isGrounded", isGrounded);
			}            
		}

		// Kills the player on collision with spikes
		if (blockCollision.gameObject.tag == "Spike" || (blockCollision.gameObject.tag == "WhitePlatform" && !isWhite) || (blockCollision.gameObject.tag == "BlackPlatform" && isWhite)){
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
        	if (soundHooks){
				soundEffectSource.Play();
			}
            Debug.Log("Reverse");
            reversed = !reversed;
            Speed = -Speed;
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y);

        }

        // Code for trampoline collision, hits player upward. 
        if (blockCollision.gameObject.tag == "Trampoline")
        {
        	if (soundHooks){
				soundEffectSource.Play();
			}
            Debug.Log("Jumped");
            rb2d.AddForce(Vector2.up * bounceMag);
            isGrounded = false;
            foreach (Animator animator in anim)
            {
                animator.SetBool("isGrounded", isGrounded);
            }
        }

        //Code for long jump
        if (blockCollision.gameObject.tag == "LongJump")
        {
        	if (soundHooks){
				soundEffectSource.Play();
			}
            Debug.Log("Longed");

            rb2d.AddForce(Vector2.right * bounceMag);
            rb2d.AddForce(Vector2.up * bounceMag);
            isGrounded = false;
            foreach (Animator animator in anim)
            {
                animator.SetBool("isGrounded", isGrounded);
            }

            StartCoroutine(LongJump());
        }

    }
}
