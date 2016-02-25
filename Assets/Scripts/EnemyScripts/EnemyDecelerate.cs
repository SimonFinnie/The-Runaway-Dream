using UnityEngine;
using System.Collections;

public class EnemyDecelerate : AlienMoveLeft {

	public float deceleration;
	public float minSpeed;



	// Update is called once per frame
	public override void Update () {
		base.Update ();
		speed -= deceleration * Time.deltaTime;
		if (speed < minSpeed) {
			speed = minSpeed;
		}
	
	}
}
