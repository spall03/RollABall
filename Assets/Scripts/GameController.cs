using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	static public GameController S;

	public int numPickups;
	public GameObject prefabPickup;

	public Text countText;
	public Text winText;

	private int count; //score counter
	private float winTimeInSeconds;
	private bool gameOver;

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

		for (int i = 0; i < numPickups; i++){
			
			GameObject newPickup = Instantiate (prefabPickup);
			
			Vector3 newPosition = new Vector3 (Random.Range (-8f, 8f), 0.5f, Random.Range (-8f, 8f));
			newPickup.transform.position = newPosition;
			
		}
	
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
