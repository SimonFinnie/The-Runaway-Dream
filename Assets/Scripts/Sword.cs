using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    public float damage;
	public float speed = 1;
	public float rotateSpeed = 180;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (rotateSpeed * Time.deltaTime * Vector3.forward);
		transform.RotateAround (transform.parent.position, Vector3.forward, rotateSpeed * Time.deltaTime);
		//transform.Translate (Vector3.up * speed * Time.deltaTime);
	}
}
