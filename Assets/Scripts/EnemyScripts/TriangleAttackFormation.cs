using UnityEngine;
using System.Collections;

public class TriangleAttackFormation : BaseEnemy {


	public float dropSpeed;
	public float riseSpeed;
	public float stillTime;
	public float turnPoint;
	int state = 0;

	public override void Start() {
		base.Start ();
		dropSpeed *= Mathf.Sign (transform.position.y);
		turnPoint *= Mathf.Sign (transform.position.y);
		riseSpeed *= Mathf.Sign (dropSpeed);
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		transform.Translate (Vector3.left * speed * Time.deltaTime);
		if (state == 0) {
			transform.Translate (Vector3.up * dropSpeed * Time.deltaTime);
			if ( Mathf.Sign(transform.position.y - turnPoint) == Mathf.Sign(dropSpeed) ){
				state = 1;
			}
		} else if (state == 1) {
			stillTime -= Time.deltaTime;
			if (stillTime <= 0f) {
				state = 2;
			}
		} else if (state == 2) {
			transform.Translate(Vector3.down * riseSpeed * Time.deltaTime);
		}
	
	}
}
