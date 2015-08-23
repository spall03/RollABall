using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb; //private variable to hold reference to the player's rigidbody component

	private int count; //score counter

	private float winTimeInSeconds;

	void Start(){

		rb = GetComponent<Rigidbody>(); //assign that component to that private variable
		count = 0;
		winText.text = ""; //starts empty
		SetCountText();

	}

	void Update(){



	}

	void FixedUpdate(){

		float moveHorizontal = Random.Range(-1.0f, 1.0f); 
		float moveVertical = Random.Range (-1.0f, 1.0f);

//		float moveHorizontal = Input.GetAxis("Horizontal");
//		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag("Pickup")){

			other.gameObject.SetActive(false);
			count++;
			SetCountText();

		}

	}

	void SetCountText(){

		countText.text = "Count: " + count.ToString(); //update UI

		if (count >= 11)
			winTimeInSeconds = Time.time;
			winText.text = "You Win! It took you " + winTimeInSeconds + " seconds.";

		}

	}


}
