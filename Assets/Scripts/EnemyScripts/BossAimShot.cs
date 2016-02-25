using UnityEngine;
using System.Collections;

public class BossAimShot : BaseEnemy {

    public float rotateSpeed = -10;
	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		transform.RotateAround(transform.parent.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        base.Update();
        //transform.eulerAngles = new Vector3(0, 0, 0);

    }
}
