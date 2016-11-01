using UnityEngine;
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

    public Camera playerCamera;


    //Animator to cause GameOver
    public Animator GameOver;

	Rigidbody2D rb2d;
	Material playerMat;

	//loads the animation call script
	private List<Animator> anim = new List<Animator>();
	private List<SpriteRenderer> spriteRend = new List<SpriteRenderer>();

	// Use this for initialization
	void Start () {
		GetComponentsInChildren<Animator> (true, anim);
		GetComponentsInChildren<SpriteRenderer> (true, spriteRend);
		CurrentLevelInt = Application.loadedLevel;
        playerMat = GetComponent<Renderer>().material;
		rb2d = GetComponent<Rigidbody2D>();
		//playerMat.color = Color.red;
		rb2d.velocity = new Vector2(Speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);

		if (rb2d.position.y <= -10){
			isDead = true;
		}
		if (isDead){
            Debug.Log("Died");
			rb2d.velocity = rb2d.velocity*(0);

            //This code added to trigger Gameover Anim.
            GameOver.SetTrigger("isDead");
		}

		//Jumping
		if (Input.GetButtonDown("Jump") && isGrounded){
			//print("Jumping");
			rb2d.AddForce(Vector2.up * JumpStrength);
			isGrounded = false;
			foreach (Animator animator in anim){
				animator.SetBool ("isGrounded", isGrounded);
			}
		}

		//Mid-air swapping
		if (Input.GetKeyDown(KeyCode.Q) && isGrounded == false) {
			if (isWhite) {
				//animController.setAnimation ("jump_white");
			} else if (!isWhite) {
				//animController.setAnimation ("jump_black");
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)){
			isWhite = !isWhite;
			//anim.SetBool("isWhite", isWhite);
			foreach (SpriteRenderer sprites in spriteRend){
				sprites.enabled = !sprites.enabled;
			}
			foreach (Animator anims in anim){
				//anims.enabled = !anims.enabled;
			}
		}

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(CurrentLevelInt);
        }


        //This is test code to kill character and view GameOver screen.
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDead = true;
        }


    }

	void OnCollisionEnter2D(Collision2D blockCollision){
        //Debug.Log("blockCollision.gameObject.tag = " + blockCollision.gameObject.tag);
		if (blockCollision.gameObject.tag == "WhitePlatform" || blockCollision.gameObject.tag == "BlackPlatform"){
			isGrounded = true;

			foreach (Animator anims in anim){
				anims.SetBool ("isGrounded", isGrounded);
			}

            //Debug.Log("New Collision");

            //anim.SetBool ("isGrounded", isGrounded);
            Vector2 direction = blockCollision.gameObject.transform.position - this.transform.position;
            //Debug.Log(direction);

            Vector2 directionRight = new Vector2((float)1.513132, (float) -0.5);
            //Debug.Log("Right is" + directionRight.ToString());
            //Debug.Log("direction compare" + direction.ToString() + "and" + directionRight.ToString());
            if (direction.ToString() == directionRight.ToString())
            {
                //Debug.Log("Reverse triggered");
                Speed = -Speed;   
                             
            }

		}

		if (blockCollision.gameObject.tag == "Spike"){
			Debug.Log("Fuck, that hurt");
			isDead = true;
		}

        //Code for trampoline collision, reverses Y momentum.
        if (blockCollision.gameObject.tag == "Trampoline")
        {
            //Debug.Log("bounce Triggered");
            //Find the magnitude of the moving figure, push up by that power times bounceMag.
            var bounceVelocity = System.Math.Abs(rb2d.velocity.magnitude);
            rb2d.AddForce((Vector2.up * bounceVelocity * bounceMag));
        }
        //Code for reverse block
        
	}
}
