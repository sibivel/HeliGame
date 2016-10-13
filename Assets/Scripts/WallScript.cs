using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	private EdgeCollider2D ec;
	private Mesh mesh;
	public int[] wallVertexNumbers = new int[2];
	private GameObject heli;
	private float heliX;
	private Transform t;
	// Use this for initialization
	void Start () {
		heli = GameObject.FindGameObjectWithTag ("Player");
		t = GetComponent<Transform> ();
		mesh = GetComponent<MeshFilter> ().mesh;
		ec = gameObject.GetComponent<EdgeCollider2D> ();
		if (mesh.vertexCount >= 2) {
			ec.points = new Vector2[] { mesh.vertices [wallVertexNumbers[0]], mesh.vertices [wallVertexNumbers[1]] };
		}
	}
	
	// Update is called once per frame
	void Update () {
		heliX = heli.GetComponent<Transform>().position.x;
		if (t.position.x + 10 < heliX) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.gameObject);
		Debug.Log (other.gameObject.name);
	}


}
