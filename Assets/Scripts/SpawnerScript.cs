using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	public GameObject lowerBrick;
	public GameObject upperBrick;
	public float gap;

	private float lastSpawnX = -1;
	private Transform t;
	private float z = 0f;
	public float startX;

	private float floorHeight =  1;
	private float ceilingHeight =  1;

	public float tunnelHeight;
	public float blockHeight;
	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();
		lastSpawnX = t.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (t.position.x >= lastSpawnX+gap) {
			float x = lastSpawnX + gap;
			Vector2 floorSpawn = new Vector2 (startX, -tunnelHeight);
			Vector2 ceilingSpawn = new Vector2 (startX, tunnelHeight);

			//Create bricks for floor
			GameObject floorBrick = (GameObject)Instantiate (lowerBrick, floorSpawn, Quaternion.identity);
			Mesh mesh = new Mesh ();

			Vector3[] vertices = new Vector3[4];
			vertices [0] = new Vector3( x - 0.5f, floorHeight, z);
			floorHeight = Random.value * blockHeight;

			vertices [1] = new Vector3( x + 0.5f, floorHeight, z);
			vertices [2] = new Vector3( x - 0.5f, -0.5f, z);
			vertices [3] = new Vector3( x + 0.5f, -0.5f, z);

			Vector2[] uvs = new Vector2[4];
			uvs [0] = new Vector2 (0f, 1f);
			uvs [1] = new Vector2 (1f, 1f);
			uvs [2] = new Vector2 (0f, 0f);
			uvs [3] = new Vector2 (1f, 0f);

				
			floorBrick.GetComponent<MeshFilter> ().mesh = mesh;

			mesh.vertices = vertices;
			mesh.uv = uvs;
			mesh.triangles = new int[6]{ 0, 1, 2, 2, 1, 3 };
			mesh.subMeshCount = 2;

			//create bricks for ceiling
			GameObject ceilingBrick = (GameObject)Instantiate (upperBrick, ceilingSpawn, Quaternion.identity);
			mesh = new Mesh ();

			vertices = new Vector3[4];
			vertices [0] = new Vector3( x - 0.5f, 0.5f, z);
			vertices [1] = new Vector3( x + 0.5f, 0.5f, z);
			vertices [2] = new Vector3( x - 0.5f, -ceilingHeight, z);
			ceilingHeight = Random.value * blockHeight;
			vertices [3] = new Vector3( x + 0.5f, -ceilingHeight, z);

			uvs = new Vector2[4];
			uvs [0] = new Vector2 (0f, 1f);
			uvs [1] = new Vector2 (1f, 1f);
			uvs [2] = new Vector2 (0f, 0f);
			uvs [3] = new Vector2 (1f, 0f);


			ceilingBrick.GetComponent<MeshFilter> ().mesh = mesh;

			mesh.vertices = vertices;
			mesh.uv = uvs;
			mesh.triangles = new int[6]{ 0, 1, 2, 2, 1, 3 };
			mesh.subMeshCount = 2;

			//save spawn location
			lastSpawnX = x;
		}

	}
}
