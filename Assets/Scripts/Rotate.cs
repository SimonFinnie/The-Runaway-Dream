using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	float angle = 0;
	public float speed = 40;

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = (Vector3.forward * (angle%360));
		angle += speed * Time.deltaTime;
		if (angle > 360) {
			angle = angle%360;
		}
	}
}
