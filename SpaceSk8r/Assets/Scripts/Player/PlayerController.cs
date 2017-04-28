using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector2 boardVelocity;
	public float boardRotation;
	RaycastHit2D rayHit;
	GameObject hitInfo;
	float speed = 17;
	float slowForce = -12;
	Rigidbody2D BoardRigidbody;
	public bool onGround;
	public static bool deathToggle = false;
	float distanceToGround;



	// Use this for initialization
	void Start () 
	{
		BoardRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		boardVelocity = BoardRigidbody.velocity;
		boardRotation = BoardRigidbody.rotation;
		Debug.Log (deathToggle);
		//moves character
		BoardRigidbody.AddRelativeForce (transform.right * speed);

		//backwards slows you
		if(Input.GetAxisRaw ("Horizontal") == -1)
		{
			BoardRigidbody.AddRelativeForce (transform.right * slowForce);
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
					BoardRigidbody.AddRelativeForce (transform.up * 200);
				}
			}
		}
		Debug.DrawLine(rayHit.point, transform.position , Color.red);
		//if(onGround == true && Input.GetAxisRaw ("Vertical") == 1)
		//{
			//transform.rotation = Quaternion.Euler(0, 0, 0);
			//BoardRigidbody.AddRelativeForce (transform.up * 200);
		//}
			
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

	/*void OnCollisionEnter2D (Collision2D otherObject)
	{
		if (otherObject.gameObject.tag == "Ground") 
		{
			onGround = true;
		}
	}

	void OnCollisionExit2D (Collision2D otherObject)
	{
		if (otherObject.gameObject.tag == "Ground") 
		{
			onGround = false;
		}
	}
*/

}