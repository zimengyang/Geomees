using UnityEngine;
using System.Collections;

public class SphereControl : MonoBehaviour {

	private Rigidbody rigidBody;
	private float moveForwardForce = 25.0f;
	private float moveSideForce = 25.0f;
	private float MaxVelocity = 3.0f;
	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Magnitude (rigidBody.velocity) > MaxVelocity)
			return;
		
		if (Input.GetKey (KeyCode.W)) 
		{
			rigidBody.AddForce (0,0,moveForwardForce);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			rigidBody.AddForce (0,0,-moveForwardForce);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			rigidBody.AddForce (-moveSideForce,0,0);
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			rigidBody.AddForce (moveSideForce,0,0);
		}
	
	}
}
