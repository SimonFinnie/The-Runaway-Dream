using UnityEngine;
using System.Collections;

public class MoveX : MonoBehaviour {

	public bool left = true;
	public float speed = 1;
	
	// Update is called once per frame
	void Update () {
		if (left) {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		} else {
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
	}
}
