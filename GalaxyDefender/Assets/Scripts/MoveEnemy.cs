using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction;
	private Vector2 movement;
	public int randomInt;
	public float movingTime = 3f;      
	int location;
	void Start () {
		randomInt = Random.Range(1,3);
		
	}

	void Update () {
		if (randomInt == 1) {
			direction = new Vector2(1, 0);
			location = 2;
		} else {
			direction = new Vector2(-1, 0);
			location = 1;
		}
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

	
}
