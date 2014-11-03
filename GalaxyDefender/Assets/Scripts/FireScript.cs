using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	void Update () {
		Collision2D collision1 = null;
		OnCollisionEnter2D(collision1);
		
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision != null){
			Destroy (gameObject);
		}
		
	}
}