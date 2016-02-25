using UnityEngine;
using System.Collections;

public class AlienMoveLeft : BaseEnemy {


	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		transform.Translate (Vector3.left * speed * Time.deltaTime, Space.World);
	
	}
}
