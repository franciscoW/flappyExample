using UnityEngine;
using System.Collections;

public class RepetBackgroud : MonoBehaviour {

	private BoxCollider2D box2d;
	private float platformlength;

	private void Awake(){
		box2d = GetComponent<BoxCollider2D> ();
	}
	// Use this for initialization
	void Start () {
		platformlength = box2d.size.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < -platformlength) {
			RepositionBackgroud ();
		}
	}

	private void RepositionBackgroud(){
		transform.Translate (Vector2.right * platformlength * 2);
	}
}
