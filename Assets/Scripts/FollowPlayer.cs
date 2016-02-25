using UnityEngine;
using System.Collections;

public class FollowPlayer : BaseEnemy {

	public float speedY = 4;
	public float speedX = 2;

	Transform ship;
	Vector3 playerPos;
	float difY;
	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		playerPos = GameMaster.level.player.transform.position;
		if(playerPos[1] < transform.position[1] - 0.2 || playerPos[1] > transform.position[1] + 0.2){
			difY = playerPos[1] - transform.position[1];
			difY /= Mathf.Abs (difY);
			transform.Translate(speedY * Vector3.up*difY*Time.deltaTime);
		}
		transform.Translate (Vector3.left * speedX * Time.deltaTime);
	}
}
