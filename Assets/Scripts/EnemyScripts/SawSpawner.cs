using UnityEngine;
using System.Collections;

public class SawSpawner : MonoBehaviour {

	public Transform saw;
	public float rightmult = 0.18f;
	public float upmult = 0;
	// Use this for initialization
	void Start () {
		saw = Instantiate (saw);
		saw.parent = transform;
		saw.position = transform.position;
		saw.Translate (Vector3.right * rightmult);
		saw.Translate (Vector3.up * upmult);
	}
}
