using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 500.0f;
	[SerializeField] bool isGrounded = true;
	[SerializeField] GameObject Pin;

    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {

    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && !jumpPressed && isGrounded)
			jumpPressed = true;

		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
			Flip();
		if (jumpPressed && isGrounded)
			Jump();
		if (Input.GetButton("Fire1")) {
			Instantiate(Pin, transform.position, Quaternion.identity);
		}
	}

    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    void Jump()
	{
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		jumpPressed = false;
		isGrounded = false;
	}

    void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
			isGrounded = true;
	}

	public bool isRight() {
		return isFacingRight;
	}
}