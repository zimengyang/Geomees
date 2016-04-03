using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	[SerializeField] public Transform target;
	Vector3 offSet;

	// Use this for initialization
	void Start () {
		offSet = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 desiredPos = target.position - offSet;
		//transform.position = Vector3.Lerp (transform.position,desiredPos,Time.deltaTime * 10.0f);
		transform.position = desiredPos;
	}
}
