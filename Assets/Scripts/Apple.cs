using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	public static float     bottomY = -20f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );
			// Get a reference to the ApplePicker component of Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); // 1
			// Call the public AppleDestroyed() method of apScript
			apScript.AppleDestroyed();     
		}                                 // 2
	}

	void OnCollisionEnter( Collision coll ) {                               // 2
		// Find out what hit this basket
		GameObject apple = this.gameObject;
		GameObject collidedWith = coll.gameObject;                          // 3
		if (collidedWith.tag == "Basket") {                                // 4
						Destroy (apple);

						ApplePicker.currentScore += 100;
						// Convert the score back to a string and display it
						ApplePicker.scoreGT.text = ApplePicker.currentScore.ToString ();
			if (ApplePicker.currentScore > HighScore.score) {
				HighScore.score = ApplePicker.currentScore;
						}

				}
}
}