using UnityEngine;
using System.Collections;

public class MultiShot : MonoBehaviour {

	public Transform shotType;
	public int numShots;
	public float angularSpread;
	public float linearSpread;

	// Use this for initialization
	void Start () {
		if (numShots > 1) {
			float angle = angularSpread / 2;
			float displacement = linearSpread / 2;
			for (int i = 0; i < numShots; i++) {
				Transform s = Instantiate(shotType);
				s.parent = transform.parent;
				s.position = transform.position;
				s.rotation = transform.rotation;
				s.Translate(Vector3.up * displacement);
				s.Rotate(Vector3.forward * angle);
				displacement -= linearSpread / (numShots-1);
				angle -= angularSpread / (numShots-1);
			}
		}
		
		Destroy (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
