using UnityEngine;
using System.Collections;

public class Alien2 : BaseEnemy {

	public float speedX = -4;
	public float gravity = 5;
	public float speedY = 2;

    public override void Start()
    {
        base.Start();
        
    }

    public override void Update(){
		base.Update ();
		transform.Translate (new Vector3((speedX + (time * gravity)) * Time.deltaTime,Time.deltaTime * speedY,0));
	}
}