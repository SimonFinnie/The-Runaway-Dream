using UnityEngine;
using System.Collections;

public class Alien : BaseEnemy {

    public override void Start()
    {
        base.Start();
    }


    public override void Update(){
		base.Update ();
		transform.Translate (Vector3.up * speed * Time.deltaTime);
	}
}