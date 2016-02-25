using UnityEngine;
using System.Collections;

public class RotateAroundParent : MonoBehaviour {

	float radius;

	// Use this for initialization
	void Start () {
		radius = -(transform.position - transform.parent.position).magnitude;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3 (radius, 0, 0);
		float ang = Vector2.Angle(GameMaster.level.player.transform.position - transform.parent.position, Vector3.left);
		if (Vector3.Cross(GameMaster.level.player.transform.position - transform.parent.position, Vector3.left).z > 0) {
			ang = 360 - ang;
		}
		transform.RotateAround (transform.parent.position, Vector3.forward, ang);
	
	}
}
