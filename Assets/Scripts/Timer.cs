using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public GUIText timer;
	float start;
	// Use this for initialization
	void Start () {

		start = 0;
		timer.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Apple").Length!=0) {
		
			timer.text = (start+=Time.deltaTime).ToString("#.00");

				}
	}
}
