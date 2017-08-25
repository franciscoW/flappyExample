using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject gameOverTxt;
	public bool gameOver;
	public static GameController instance;
	public float scrollSpeed = -1.5f;

	private int score = 0 ;
	public Text scoreTxt;

	private void Awake(){
		if (GameController.instance == null) {
			GameController.instance = this;
		} else {
			if (GameController.instance != this) {
				Destroy (gameObject);
			}//fin del if 
		}//fin del else
	}//fin del Awake

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver && Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene ("Main");
		}
	}

	public void BirdDie(){
		gameOverTxt.SetActive (true);
		gameOver = true;
	}


	public void BirdScore(){

		if (gameOver) return;

		score++;
		scoreTxt.text = "Score : " + score;
		SoundSystem.instance.PlayWin ();
	}

	private void OnDestory(){
	
		if (GameController.instance == this) {
			GameController.instance = null;
		}
	}
}
