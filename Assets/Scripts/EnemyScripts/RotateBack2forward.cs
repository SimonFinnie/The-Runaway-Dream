using UnityEngine;
using System.Collections;

public class RotateBack2forward : MonoBehaviour {

	public float magnitude;
	float rotation;
	public float rate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * rate * Time.deltaTime);
		rotation += rate * Time.deltaTime;
		if (rotation * Mathf.Sign(rate) >= magnitude) {
			rate *= -1;
		}
	
	}
}
