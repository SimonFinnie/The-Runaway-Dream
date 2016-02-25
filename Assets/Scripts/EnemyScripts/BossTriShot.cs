using UnityEngine;
using System.Collections;

public class BossTriShot : BaseEnemy {

    public float rotateSpeed = 10;

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        transform.RotateAround(transform.parent.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 0);

    }
}
