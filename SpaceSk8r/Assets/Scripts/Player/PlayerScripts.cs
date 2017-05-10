using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScripts : MonoBehaviour {
	GameObject skateboard;
	public int currency = 0;
	public int score = 0;

	// Use this for initialization
	void Start () 
	{
		skateboard = GameObject.Find("Board");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerController.deathToggle == true) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			PlayerController.deathToggle = false;

		}
	}


	void OnTriggerEnter2D (Collider2D otherObject)
	{
		if (otherObject.gameObject.tag == "Coin") 
		{
			currency = currency + 1;
			Destroy (otherObject.gameObject);
		}
		if (otherObject.gameObject.tag == "Ground") 
		{
			PlayerController.deathToggle = true;
		}
	}

	void OnTriggerStay2D (Collider2D otherObject)
	{
		if (otherObject.gameObject.tag == "ScoreZone") 
		{
			
			//if trick = kickflip
			//if trick = ollie
			//if trick = etc

		}
	}
}