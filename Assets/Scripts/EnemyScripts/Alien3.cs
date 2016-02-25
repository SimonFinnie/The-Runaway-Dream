using UnityEngine;
using System.Collections;

public class Alien3 : MonoBehaviour {
	
	public float speedX = 5;
	public float speedY = 5;
	public float gravity = 5;
	public float Vi = -4;
    float time = 0;

		
	void Ark(){
		transform.Translate (new Vector3((Vi + (time * gravity)) * Time.deltaTime,Time.deltaTime * speedY,0));
	}

	void Move(){
		transform.Translate (new Vector3( speedX*Time.deltaTime,0,0));
	}
	
    void Update(){
        time += Time.deltaTime;
		if (Vi + (time * gravity) >= 0) {
			Move ();
		} else {
			Ark ();
		}
	}
}