using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

	public float wValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		float rotationX = Input.GetAxis("Vertical");
		float rotationZ = Input.GetAxis ("Horizontal");

		transform.rotation = new Quaternion(rotationX, 0.0f, -rotationZ, wValue);

	}
}
