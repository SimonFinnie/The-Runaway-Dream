using UnityEngine;
using System.Collections;

public class ReflectEnemy : MonoBehaviour {

	public bool x;
	public bool y;
	
	void Start () {
		if (x && transform.position.x != 0) {
			x = false;
			ReflectEnemy e = Instantiate(this);
			e.transform.position = new Vector3(transform.position.x * -1f, transform.position.y, transform.position.z);
			e.transform.parent = transform.parent;
		}
		if (y && transform.position.y != 0) {
			y = false;
			ReflectEnemy e = Instantiate(this);
			e.transform.position = new Vector3(transform.position.x , transform.position.y * -1f, transform.position.z);
			e.transform.parent = transform.parent;
		}

	
	}
	

}
