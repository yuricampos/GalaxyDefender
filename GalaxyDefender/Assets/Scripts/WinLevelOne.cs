using UnityEngine;
using System.Collections;

public class WinLevelOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (renderer.IsVisibleFrom(Camera.main)) {
//			GameOverScript script = new<GameOverScript>();

			transform.parent.gameObject.AddComponent<GameOverScript>();
				}
	
	}
}
