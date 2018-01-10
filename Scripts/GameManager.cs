using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject canvas;
	public bool UsingVR = false;
	public int score = 0;
	public Text scoreText;

	private bool lastUsingVR = false;

	public void Update(){
		if (lastUsingVR != UsingVR) {
			lastUsingVR = UsingVR;
			if (UsingVR)
				canvas.SetActive (false);
			else
				canvas.SetActive (true);
		}

		scoreText.text = "SCORE: " + score;
	}
}
