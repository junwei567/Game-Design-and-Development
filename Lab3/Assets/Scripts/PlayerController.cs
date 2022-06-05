using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float upSpeed;
    public float maxSpeed = 10;

    private Rigidbody2D marioBody;
    private float moveHorizontal;
    private bool onGroundState = true;

    private SpriteRenderer marioSprite;
    private bool faceRightState = true;

    // public Transform enemyLocation;
    // public Text scoreText;
    // private int score = 0;
    private bool countScoreState = false; 

    public GameObject restartCanvas;

    private Animator marioAnimator;
    private AudioSource marioAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Set to be 30 FPS
        Application.targetFrameRate =  30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        restartCanvas.gameObject.SetActive(false);
        marioAnimator = GetComponent<Animator>();
        marioAudioSource = GetComponent<AudioSource>();
    }

    // FixedUpdate may be called once per frame. See documentation for details.
    void  FixedUpdate()
    {
        // dynamic rigidBody
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0) {
            Vector2 movement = new Vector2(moveHorizontal, 0);
            if (marioBody.velocity.magnitude < maxSpeed) marioBody.AddForce(movement * speed);
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) {
            // stop
            marioBody.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown("space") && onGroundState) {
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            countScoreState = true; // check if Gomba is underneath
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) {
            onGroundState = true;
            marioAnimator.SetBool("onGround", onGroundState);
            countScoreState = false;
            // scoreText.text = "Score: " + score.ToString();
        }

        if (col.gameObject.CompareTag("Obstacles") && Mathf.Abs(marioBody.velocity.y) < 0.01f) {
            onGroundState = true;
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }

    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
        marioAnimator.SetBool("onGround", onGroundState);

        // toggle state
        if (Input.GetKeyDown("a") && faceRightState){
            faceRightState = false;
            marioSprite.flipX = true;
            if (Mathf.Abs(marioBody.velocity.x) >  1.0) marioAnimator.SetTrigger("onSkid");

        }

        if (Input.GetKeyDown("d") && !faceRightState){
            faceRightState = true;
            marioSprite.flipX = false;
            if (Mathf.Abs(marioBody.velocity.x) >  1.0) marioAnimator.SetTrigger("onSkid");

        }

        // if (!onGroundState && countScoreState) {
        //     if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f) {
        //         countScoreState = false;
        //         score++;
        //         Debug.Log(score);
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Gomba")) {
            Debug.Log("Collided with Gomba!");
            Time.timeScale = 0.0f;
            restartCanvas.gameObject.SetActive(true);
        }
    }

    void  PlayJumpSound(){
        marioAudioSource.PlayOneShot(marioAudioSource.clip);
    }
}
