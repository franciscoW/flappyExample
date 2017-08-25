using UnityEngine;
using System.Collections;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rgb2d;
	// Use this for initialization

	private void Awake(){
		
		rgb2d = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		rgb2d.velocity = new Vector2 (GameController.instance.scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver) {
			rgb2d.velocity = Vector2.zero;
		}
	}
}
