using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D mushroomBody;
    private bool onGround;
    private int moveRight = 1;
    private bool touchPlayer = false;
    private bool launched = false;
    // Start is called before the first frame update
    void Start()
    {
        mushroomBody = GetComponent<Rigidbody2D>();
        mushroomBody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        launched = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (!launched || touchPlayer) return;
        mushroomBody.velocity = new Vector2(speed*moveRight, mushroomBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!touchPlayer && other.gameObject.CompareTag("Player")) {
            Debug.Log("Collided with Mushroom!");
            touchPlayer = true;
            mushroomBody.velocity = Vector2.zero;
            // Destroy(gameObject);
            return;
        }
        if (other.GetContact(0).normal == Vector2.up) return; // prevent the mushroom from colliding with the edge of platforms??
        if (other.gameObject.CompareTag("Obstacles")) {
            moveRight *= -1;
        }
    }

    private void OnBecameInvisible() {
        // Destroy(gameObject);
    }

}
