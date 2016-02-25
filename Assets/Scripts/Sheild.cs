using UnityEngine;
using System.Collections;

public class Sheild : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Shot s = other.GetComponent<Shot> ();
		if (s != null && s.enemyShot) {
			Destroy(other.gameObject);
		}
	}
}
