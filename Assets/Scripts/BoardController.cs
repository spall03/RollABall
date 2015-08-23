using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

	public float wValue;

	public GameObject prefabPickup;
	public int numPickups;
	

	// Use this for initialization
	void Start () {

		//add pickups at random positions on the game board
		for (int i = 0; i < numPickups; i++){

			GameObject newPickup = Instantiate (prefabPickup);

			Vector3 newPosition = new Vector3 (Random.Range (-8f, 8f), 0.5f, Random.Range (-8f, 8f));
			newPickup.transform.position = newPosition;

		}

	
	}


	void FixedUpdate() {

		float rotationX = Input.GetAxis("Vertical");
		float rotationZ = Input.GetAxis ("Horizontal");

		transform.rotation = new Quaternion(rotationX, 0.0f, -rotationZ, wValue);

	}
	

}

