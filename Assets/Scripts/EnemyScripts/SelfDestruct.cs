using UnityEngine;
using System.Collections;

public class SelfDestruct : BaseEnemy {

    public Transform shot;
    public int shotCount = 10;

	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void Kill()
    {
        Transform curShot;
        base.Kill();
        for (int n = 1; n <= shotCount; n++)
        {
            curShot = Instantiate(shot);
            shot.position = transform.position;
            shot.eulerAngles = Vector3.forward * (n * 360 / shotCount);
        }

    }
}
