using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction;
	private Vector2 movement;
	public int randomInt;
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

	public void changeDirections(){
		if (location == 1) {
			direction = new Vector2(1, 0);
		} else {
			direction = new Vector2(-1, 0);
		}
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);

	}

}
