using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	private Vector2 movement;
	public float speed = 0.008f;
	void Update ()
	{
		transform.Translate(new Vector2(0, -(speed)));
		//movement = new Vector2 (0f, Time.time * speed);
	}

	}