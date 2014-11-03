using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	IEnumerator Refresh(){
		yield return new WaitForSeconds(0.2f);
	}
	
	void Update () {
		Collision2D collision1 = null;
		OnCollisionEnter2D(collision1);
		
	}
	
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision != null){
			//Refresh();
			PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
			player.increaseShot();
			Destroy (gameObject);
		}
		
	}
}
