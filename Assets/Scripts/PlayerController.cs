using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb; //private variable to hold reference to the player's rigidbody component
	

	void Start(){

		rb = GetComponent<Rigidbody>(); //assign that component to that private variable

	}

	void Update(){



	}

	//apply random walk to player object
	void FixedUpdate(){

		float moveHorizontal = Random.Range(-1.0f, 1.0f); 
		float moveVertical = Random.Range (-1.0f, 1.0f);

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag("Pickup")){

			GameController.S.rollOverPickup(other);

		}

	}
	


}
