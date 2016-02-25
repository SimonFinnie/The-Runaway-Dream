using UnityEngine;
using System.Collections;

public class moveLeft : BaseEnemy {

    public override void Start()
    {
        base.Start();
    }


    public override void Update(){
		base.Update ();
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
}