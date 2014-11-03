using UnityEngine;
using System.Collections;

public class TransitionThreeScript : MonoBehaviour {
	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		
		if (
			GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Back to menu"
			)
			)
		{
			Application.LoadLevel("Menu");
		}
	}