using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private bool fly;
	private bool flyWas;
	private Rigidbody2D rb;
	private Transform t;
	public float verticalAcceleration;

	public bool stop = false;
	// Use this for initialization
	void Start () {
		fly = false;
		rb = GetComponent<Rigidbody2D> ();
		t = GetComponent<Transform> ();
	}
	

	void FixedUpdate () {
		if (!stop) {
			fly = Input.GetMouseButton (0);
			if (fly != flyWas) {
				//rb.velocity = Vector2.zero;
			}

			if (fly) {
				rb.AddForce (new Vector2 (0f, verticalAcceleration));

			} else {
				rb.AddForce (new Vector2 (0f, -0.75f * verticalAcceleration));
			}

			flyWas = fly;
		}
	}

	// Update is called once per frame
	void Update() {
		
	}

	public void kill(){
		stop = true;
	}
}
