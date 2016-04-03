using UnityEngine;
using System.Collections;

public class PreciewCameraControl : MonoBehaviour {

	[SerializeField] public Transform target;

	private Vector3 offSet;

	// Use this for initialization
	void Start () {
		offSet = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position - offSet;
	}
}
