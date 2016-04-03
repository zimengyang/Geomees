using UnityEngine;
using System.Collections;

public class MeshControl : MonoBehaviour {

	[SerializeField] Mesh sphereMesh;// = GameObject.CreatePrimitive(PrimitiveType.Sphere).GetComponent<MeshFilter>().mesh;

	[SerializeField] Mesh cubeMesh;// = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<MeshFilter>().mesh;

	[SerializeField] Mesh cylinderMesh;

	[SerializeField] GameObject playerObj;

	[SerializeField] Camera mainCamera;
	[SerializeField] Camera previewCamera;

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = playerObj.transform.position;
	}

	void DeleteCollider(int type)
	{

		if(type != 1 && playerObj.GetComponent<BoxCollider> () != null)
			Destroy (playerObj.GetComponent<BoxCollider> ());
		
		if(type != 2 && playerObj.GetComponent<SphereCollider> () != null)
			Destroy (playerObj.GetComponent<SphereCollider> ());

		if(type != 3 && playerObj.GetComponent<CapsuleCollider> () != null)
			Destroy (playerObj.GetComponent<CapsuleCollider> ());
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) // to box
		{
			playerObj.GetComponent<MeshFilter> ().mesh = cubeMesh;
			DeleteCollider (1);

			if (playerObj.GetComponent<BoxCollider> () == null)
			{
				playerObj.AddComponent <BoxCollider> ();
			}
			playerObj.transform.rotation = Quaternion.Euler (0,0,0);
			playerObj.transform.localScale = new Vector3 (1,1,1);
		}

		if (Input.GetKeyDown (KeyCode.O)) // to sphere 
		{
			playerObj.GetComponent<MeshFilter> ().mesh = sphereMesh;
			DeleteCollider (2);

			if (playerObj.GetComponent<SphereCollider> () == null) 
			{
				playerObj.AddComponent <SphereCollider> ();
			}

			playerObj.transform.localScale = new Vector3 (1,1,1);
		}

		if (Input.GetKeyDown (KeyCode.P)) // to cylinder
		{
			playerObj.GetComponent<MeshFilter> ().mesh = cylinderMesh;
			DeleteCollider (3);

			if(playerObj.GetComponent<CapsuleCollider>() == null)
				playerObj.AddComponent <CapsuleCollider>();
			
			playerObj.transform.rotation = Quaternion.Euler (0,0,0);
			playerObj.transform.position = new Vector3
				(playerObj.transform.position.x,
				playerObj.transform.position.y + 0.4f,
				playerObj.transform.position.z);
			playerObj.transform.localScale = new Vector3 (1,1.8f,1);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			//playerObj.transform.position = startPosition;
			Destroy (playerObj.GetComponent<SphereControl>());
			Destroy (playerObj.GetComponent<Rigidbody> ());

			playerObj = GameObject.Instantiate (Resources.Load("player"), Vector3.zero, Quaternion.identity) as GameObject;
			playerObj.transform.position = startPosition;
			//Camera.main.GetComponent<CameraControl> ().target = playerObj.transform;
			mainCamera.GetComponent<CameraControl>().target = playerObj.transform;
			previewCamera.GetComponent<PreciewCameraControl> ().target = playerObj.transform;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			playerObj.transform.position = startPosition;
		}


		if (Input.GetKeyDown (KeyCode.Tab)) {
			mainCamera.enabled = !mainCamera.enabled;
			previewCamera.enabled = !previewCamera.enabled;
		}

	}
}
