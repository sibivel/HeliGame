using UnityEngine;
using System.Collections;

public class WallTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTiggerEnter(Collider other) {
		Destroy (other.gameObject);
		Debug.Log ("test");
	}
}
