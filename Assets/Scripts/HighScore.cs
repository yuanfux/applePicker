using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int    score = 1000;
	void Awake() {                                                          // 1
		// If the ApplePickerHighScore already exists, read it
		if (PlayerPrefs.HasKey("ApplePickerHighScore")) {                   // 2
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}
		// Assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);                  // 3
		GUIText gt = this.GetComponent<GUIText>();
		gt.text = "High Score: "+score;
	}
	void Update () {


		GUIText gt = this.GetComponent<GUIText>();
		gt.text = "High Score: "+score;

		if (ApplePicker.currentScore > HighScore.score) {
			score = ApplePicker.currentScore;
		}


	}

	static public void setPlayerPrefHighScore(){


		if (score > PlayerPrefs.GetInt("ApplePickerHighScore")) {           // invokered in ApplePick
			PlayerPrefs.SetInt("ApplePickerHighScore", score);
		}
		}
}
