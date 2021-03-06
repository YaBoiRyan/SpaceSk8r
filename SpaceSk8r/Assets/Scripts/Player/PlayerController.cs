using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector2 boardVelocity;
	Vector2 forwardRay;
	public float boardRotation;
	RaycastHit2D rayHit;
	GameObject hitInfo;
	float speed = 50;
	float slowForce = -50;
	Rigidbody2D BoardRigidbody;
	public bool onGround;
	public static bool deathToggle = false;
	float distanceToGround;
	public float testDist = 1;



	// Use this for initialization
	void Start () 
	{
		BoardRigidbody = GetComponent<Rigidbody2D>();
		onGround = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		boardVelocity = BoardRigidbody.velocity;
		boardRotation = BoardRigidbody.rotation;

		//moves character
		if (boardVelocity.x <= 60 && onGround == true && Input.GetAxisRaw ("Horizontal") == 0) 
		{
			BoardRigidbody.AddRelativeForce (transform.right * speed);
		} 
		else if (Input.GetAxisRaw ("Horizontal") == -1 && boardVelocity.x >= 1) 
		{
			BoardRigidbody.AddRelativeForce (transform.right * slowForce);
		}
		else if (Input.GetAxisRaw ("Horizontal") == -1 && boardVelocity.x <= 1) 
		{
			//BoardRigidbody.AddRelativeForce (transform.right * speed);
			boardVelocity.x = 1;
		}

		//jumping
		if (Input.GetAxisRaw ("Vertical") == 1) 
		{
			rayHit = Physics2D.Raycast (transform.position, Vector3.down, 1);

			if (rayHit.collider != null) 
			{
				if (rayHit.collider.tag == "Ground") 
				{
					transform.rotation = Quaternion.Euler (0, 0, 0);
					BoardRigidbody.AddRelativeForce (transform.up * (boardVelocity.x * 45));
					onGround = true;
				}
				else
				{
					onGround = false;
				}
			}
		}
	}
	void Update()
	{
		//failure states
		if (boardRotation > 90) 
		{
			deathToggle = true;
		}

		if (boardRotation < -90) 
		{
			deathToggle = true;
		}

	}
}