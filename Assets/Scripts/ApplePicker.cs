using UnityEngine;
using System.Collections;
using System.Collections.Generic;    
public class ApplePicker : MonoBehaviour {
	public GameObject       basketPrefab;
	public int              numBaskets = 3;
	public float            basketBottomY = -14f;
	public float            basketSpacingY = 2f;
	public List<GameObject> basketList;
	public static int     currentScore;//variable for scoreGT
	public static GUIText        scoreGT;
	// Use this for initialization
	
	void Start () {
		basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO );   
		}

		// Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find("ScoreCounter");               // 2
		// Get the GUIText Component of that GameObject
		scoreGT = scoreGO.GetComponent<GUIText>();                          // 3
		// Set the starting number of points to 0
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AppleDestroyed() {                                          // 2
		//// Destroy all of the falling Apples
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");// 3
		foreach ( GameObject tGO in tAppleArray ) {
			Destroy( tGO );
		}
		//// Destroy one of the Baskets
		// Get the index of the last Basket in basketList
		int basketIndex = basketList.Count-1;
		// Get a reference to that Basket GameObject
		GameObject tBasketGO = basketList[basketIndex];
		// Remove the Basket from the List and destroy the GameObject
		basketList.RemoveAt( basketIndex );
		Destroy( tBasketGO );
		if ( basketList.Count == 0 ) {
			HighScore.setPlayerPrefHighScore();
			Application.LoadLevel( "_Scene_0" );
			currentScore=0;
		}
	}

	void OnApplicationQuit(){

		HighScore.setPlayerPrefHighScore();


		}

}
