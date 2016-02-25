using UnityEngine;
using System.Collections;

public class SpinSword : BaseEnemy{

	public Transform sword;
	public float speedX = 2;
	Transform weapon;
	public float r = 0.5f;
    public float swordDamage;
    public float damage = 10;

	// Use this for initialization
	public override void Start () {
        base.Start();
		weapon = Instantiate (sword);
		weapon.parent = transform;
		weapon.position = transform.position;
        transform.GetComponentInChildren<Sword>().damage = swordDamage;
		weapon.Translate(new Vector3(0,r-0.1f,0));
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
		transform.Translate (Vector3.left * speedX * Time.deltaTime);
	}
}
