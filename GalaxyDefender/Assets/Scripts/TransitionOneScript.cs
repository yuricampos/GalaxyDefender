﻿using UnityEngine;
using System.Collections;

public class TransitionOneScript : MonoBehaviour {
	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;
		
		if (
			GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"LEVEL 2!"
			)
			)
		{
			Application.LoadLevel("LevelTwo");
		}
		
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
}
