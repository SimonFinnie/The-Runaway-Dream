using UnityEngine;
using System.Collections;

public class TimeDelete : MonoBehaviour {

	float time;
	public float endTime = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= endTime) {
			Destroy (gameObject);
		}
	}
}
