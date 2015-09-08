using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	static public GameController S;

	public int numPickups;
	public float exclusionRadius;
	public GameObject prefabPickup;

	public Text countText;
	public Text winText;

	private int count; //score counter
	private float winTimeInSeconds;
	private bool gameOver;
	private List<Vector3> positionList; //storing pickups for position checking

	// Use this for initialization
	void Start () {

		S = this;
		gameOver = false;

		placePickups();
		initGUI();
		SetCountText();
	}

	//scattered pickups randomly across the board
	void placePickups () {

		positionList = new List<Vector3>();

		//first get a list of acceptable positions
		for (int i = 0; i < numPickups; i++){
			

			Vector3 newPosition = generateNewPosition();

			if (i == 0){

				positionList.Add(newPosition); //this is the starting point

			}
			else{

				positionList.Add(positionCheck(newPosition)); //get an acceptable position

			}


		}


		//then build and place the pickups
		foreach (Vector3 pos in positionList){ 

			GameObject newPickup = Instantiate (prefabPickup);
			newPickup.transform.position = pos;


		}
		
	}


	//check to make sure that each new pickup is adequately spaced from the other pickups already placed
	Vector3 positionCheck (Vector3 newPosition){

		foreach (Vector3 pos in positionList){


			float distance = Vector3.Distance (pos, newPosition);

			//not okay, generate new candidate position and start a new check
			if (distance < exclusionRadius){

				newPosition = generateNewPosition();
				positionCheck(newPosition);

			}
		

		}

		return newPosition;


	}

	Vector3 generateNewPosition (){

		return new Vector3 (Random.Range (-8f, 8f), 0.5f, Random.Range (-8f, 8f));

	}

	//initiates the game's GUI
	void initGUI () {

		count = 0;
		winText.text = ""; //starts empty

	}

	public void rollOverPickup (Collider other) {

		other.gameObject.SetActive(false);
		count++;
		SetCountText();

	}

	void SetCountText(){
		
		countText.text = "Pickups remaining: " + (numPickups - count).ToString(); //update UI
		
		if (count == numPickups){
			winTimeInSeconds = Mathf.Round(Time.timeSinceLevelLoad);
			winText.text = "You Win! It took you " + winTimeInSeconds + " seconds. Press R to play again.";
			gameOver = true;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver == true){

			if(Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel("Minigame"); //reset the game

		}
	
	}
}
