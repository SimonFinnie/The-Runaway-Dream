using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		float ang = Vector2.Angle(GameMaster.level.player.transform.position - transform.position, Vector3.left);
		if (Vector3.Cross(GameMaster.level.player.transform.position - transform.position, Vector3.left).z > 0) {
			ang = 360 - ang;
		}
		transform.eulerAngles = Vector3.forward*ang;
	
	}
}
