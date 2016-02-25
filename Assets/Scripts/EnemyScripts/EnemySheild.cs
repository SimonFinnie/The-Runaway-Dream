using UnityEngine;
using System.Collections;

public class EnemySheild : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Shot s = other.GetComponent<Shot> ();
		if (s != null && !s.enemyShot) {
			Destroy(other.gameObject);
		}
	}
}
