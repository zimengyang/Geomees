using UnityEngine;
using System.Collections;

public class DestinationScript : MonoBehaviour {

	[SerializeField] float rotSpeed = 5.0f;
	private float rot;

	// Use this for initialization
	void Start () {
		rot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rot += rotSpeed;
		if (rot >= 360.0f)
			rot = 0.0f;
		transform.rotation = Quaternion.Euler (0, rot, 0);
	}
}
