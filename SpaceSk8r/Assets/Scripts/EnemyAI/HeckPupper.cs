using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeckPupper : MonoBehaviour {


	Transform playerTransform;
	Transform myTransform;

	public GameObject myProjectile;
	float shootCooldown = 2;
	bool isHidden;
	Vector3 bulletPosition;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () 
	{
		playerTransform = GameObject.Find ("Alien").transform;
		myTransform = transform;
		mySprite = GetComponent <SpriteRenderer> ();
		bulletPosition = new Vector3(transform.position.x, transform.position.y);
	}

	// Update is called once per frame
	void Update () {

		//Shoot Right
		if (playerTransform.position.x - myTransform.position.x >= 10f && isHidden == false) 
		{
			bulletPosition = new Vector3 (transform.position.x + 0.2f, transform.position.y - 0.3f);
			mySprite.flipX = true;
		}

		//Shoot Left
		if (playerTransform.position.x  - myTransform.position.x <= -10f && isHidden == false)
		{
			bulletPosition = new Vector3(transform.position.x - 0.2f, transform.position.y - 0.3f);
			mySprite.flipX = false;
		}

		//Player Too Close
		if (playerTransform.position.x - myTransform.position.x <= 10f && playerTransform.position.x - myTransform.position.x >= -10f) 
		{
			//testing change

			isHidden = true;
		} 
		else 
		{
			//testing change

			isHidden = false;
		}

		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 2f;
		}
			
	}

	void Attack ()
	{
		
		GameObject bullet = (GameObject)Instantiate (myProjectile);
		bullet.transform.position = bulletPosition;
		Vector2 direction = playerTransform.transform.position - bullet.transform.position;
		bullet.GetComponent<EnemyProjectile>().setDirection (direction);
		shootCooldown = Time.time + 2f;

	}
}
