using UnityEngine;
using System.Collections;

public class BeamAttack : Attack {

	public float liveTime;
	public float damageReduction;
	private bool firing = false;
	private float fireTimeLeft = 0;
	private Transform beam;


	public override void Start() {
		base.Start();
		beam = Instantiate(shotPrefab);
		beam.parent = transform;
		beam.position = transform.position;
		beam.gameObject.SetActive(false);
	}


	
	// Update is called once per frame
	public override void FixedUpdate () {
		if (!firing) {
			base.FixedUpdate ();
		} else if (fireTimeLeft >= Time.fixedDeltaTime) {
			fireTimeLeft -= Time.fixedDeltaTime;
			timeSinceLastShot = fireCooldownTime*fireTimeLeft/liveTime;
		} else {
			fireTimeLeft = 0;
			timeSinceLastShot = 0;
			firing = false;
			beam.gameObject.SetActive(false);
			if (GetComponentInParent<PlayerShip>() != null) {
			GetComponentInParent<PlayerShip>().damageReduction /= damageReduction;
			}
		}
	
	}

	public override void Shoot() {
		// Shoot only if the fire cooldown period
		// has expired
		if(timeSinceLastShot >= fireCooldownTime && !firing) {
			charged = false;
			beam.gameObject.SetActive(true);
			beam.eulerAngles=new Vector3(0,0,0);
			firing = true;
			fireTimeLeft = liveTime;
			if (GetComponentInParent<PlayerShip>() != null) {
			GetComponentInParent<PlayerShip>().damageReduction *= damageReduction;
			}
			
			// Check if shotSound variable has been set...if yes,
			// then play it
			if(shotSound != null) {
				GameMaster.level.PlaySound(shotSound);      
			}
		}
	}
}
