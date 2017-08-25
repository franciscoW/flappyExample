using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	private bool isDead = false;
	private bool isFirstTimeDeath = true;
	private Rigidbody2D rgd2d;
	private float maxAltura	= 5.2f;

	//variables publicas
	public float upForce = 200f;
	public GameObject bird;
	public Animator animator;

	void Awake(){
		rgd2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isDead == false) {
			if (Input.GetMouseButtonDown (0) && bird.transform.position.y < maxAltura) {
				rgd2d.velocity = Vector2.zero;
				rgd2d.AddForce (Vector2.up * upForce);
				animator.SetTrigger ("Fly");
				SoundSystem.instance.PlayTap ();
				 
			}//fin del if input
		}//fin del if isDead.

	}//fin del update


	void OnCollisionEnter2D(Collision2D collesion){
		isDead = true;
		animator.SetTrigger ("Die");
		rgd2d.velocity = Vector2.zero;
		SoundSystem.instance.StopAudio ();
		Invoke ("DelayRestartScene",1f);
		if (isFirstTimeDeath) {
			SoundSystem.instance.PlayDie ();
			isFirstTimeDeath = false;
		}
			
	}
 

	private void DelayRestartScene(){
		GameController.instance.BirdDie ();
	}
}//fin del component
