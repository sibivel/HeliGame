using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	private Transform t;

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject heli = GameObject.Find ("heli");
		if(heli != null)
			t.position = new Vector3 (heli.transform.position.x, t.position.y, t.position.z);
	}
}
