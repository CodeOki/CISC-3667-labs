using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour {

	[SerializeField] float speed = 20f;
	[SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
	[SerializeField] GameObject player;
    [SerializeField] AudioSource audioPlayer;
    // [SerializeField] GameObject scoreKeeper;

    void Start() {

        speed = 10;
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (!player.GetComponent<Movement>().isRight()) {
            movement = -speed;
        } else {
            movement = speed;
        }
        rigid.velocity = new Vector2(movement, 0);
            /* if (scoreKeeper == null)
            scoreKeeper = GameObject.Find("Game Events");
            */
        }
    void Update()
    {

    }
    void FixedUpdate() {
        if (transform.position.x > 12 || transform.position.x < -12) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Enemy") {
            GameObject.Find("Sound").GetComponent<ExplosionSound>().playAudio();
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    // scoreKeeper.GetComponent<ScoreKeeper>().AddPoints(1);
        
    }
}