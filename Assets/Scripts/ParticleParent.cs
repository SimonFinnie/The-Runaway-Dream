using UnityEngine;
using System.Collections;

public class ParticleParent : MonoBehaviour {

	ParticleSystem[] particles;

	// Use this for initialization
	void Start () {
		particles = GetComponentsInChildren<ParticleSystem> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (ParticleSystem s in particles) {
			if (s.IsAlive()) {
				return;
			}
		}

		Destroy (gameObject);

	
	}
}
