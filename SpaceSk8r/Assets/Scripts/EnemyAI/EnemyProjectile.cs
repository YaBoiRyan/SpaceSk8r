using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

	float speed;
	Vector2 _direction;

	public void setDirection(Vector2 direction)
	{
		_direction = direction.normalized;

	}
		
	void Start () 
	{
		speed = 15f;
	}
		
	void Update () 
	{
		Vector2 position = transform.position;
		position += _direction * speed * Time.deltaTime;
		transform.position = position;
	}
}
