using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour {

	public int ColumnPoollSize = 5 ;
	private GameObject[] columns;
	public GameObject columnPrefab;
	private Vector2 objPoolPos	= new Vector2 (-11.46f, 1.92f);
	private float timeSince ;
	public float rateTimeCol;
	public float colMinY = -0.37f;
	public float colMaxY = 2.89f;
	private float colPosX = 9.57f;
	private int currCol;

	// Use this for initialization
	void Start () {

		columns = new GameObject[ColumnPoollSize];

		for(int i = 0 ; i < ColumnPoollSize; i++){
			columns [i] =(GameObject) Instantiate (columnPrefab,objPoolPos,Quaternion.identity);
		}
		setColumn ();
	}
	
	// Update is called once per frame
	void Update () {

		timeSince += Time.deltaTime; 

		if( ! GameController.instance.gameOver &&  timeSince >= rateTimeCol){
			 
			timeSince = 0;
			setColumn ();
		}
	}

	void setColumn(){

		float ranPosCol = Random.Range (colMinY, colMaxY);
		columns [currCol].transform.position = new Vector2 (colPosX,ranPosCol);
		currCol++;
		if (currCol >= ColumnPoollSize) {
			currCol = 0;
		}
	}
}
