using UnityEngine;
using System.Collections;

public class FlyToPlayer : BaseEnemy {


	public Transform saw;
	public float r = 0.45f;

	public override void Start () {
		base.Start ();
		healthbarDrop = healthBar.transform.localPosition;
		if (saw != null) {
			saw = Instantiate (saw);
			saw.position = transform.position;
			saw.Translate (Vector3.left * r);
			saw.Translate (Vector3.back * 0.01f);
			saw.parent = transform;
		}
	}
	

	public override void Update () {
		float ang = Vector2.Angle(GameMaster.level.player.transform.position - transform.position, Vector3.left);
		if (Vector3.Cross(GameMaster.level.player.transform.position - transform.position, Vector3.left).z > 0) {
			ang = 360 - ang;
		}
		transform.eulerAngles = Vector3.forward*ang;
		base.Update ();
		transform.Translate (Vector3.left * speed * Time.deltaTime);

	
	}
}
