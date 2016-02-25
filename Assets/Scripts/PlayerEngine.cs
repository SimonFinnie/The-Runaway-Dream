using UnityEngine;
using System.Collections;

public class PlayerEngine : MonoBehaviour {

	public float magnitude;
	PlayerShip player;

	// Use this for initialization
	void Start () {
	
		player = GetComponentInParent<PlayerShip> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = Vector3.forward * player.direction * magnitude;
	
	}
}
