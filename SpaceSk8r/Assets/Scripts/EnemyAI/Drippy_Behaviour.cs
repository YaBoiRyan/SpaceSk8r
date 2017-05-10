using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drippy_Behaviour : MonoBehaviour {

	public GameObject myProjectile;
	float shootCooldown = 1;
	Vector3 bulletPosition;

	// Use this for initialization
	void Start () 
	{
		bulletPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shootCooldown <= Time.time)
		{
			GameObject bullet = (GameObject)Instantiate (myProjectile);
			bullet.transform.position = bulletPosition;
			shootCooldown = Time.time + 1f;
		}
	}
}
