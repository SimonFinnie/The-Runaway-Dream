using UnityEngine;
using System.Collections;

public class ReubenBossRoot : BaseEnemy {

	float DamageTimeleft;
	float DamageCooldownTime = 0.1f;
	public int ActiveState;
    protected bool started;
	public int AdvanceState;


	public override void Start ()
	{
		base.Start ();

	}

	public override void Update() {
		base.Update();
		if (DamageCooldownTime > 0) {
			SpriteRenderer s = GetComponent<SpriteRenderer>();
			DamageTimeleft -= Time.deltaTime;
			if (DamageTimeleft <= 0) {
				DamageTimeleft = 0;
				s.color = Color.white;
			} else {
				s.color = Color.red;
			}
		}
	}

	public virtual void setState(int state) {
		if (state >= ActiveState) {
            started = true;
			foreach (Collider2D c in GetComponents<Collider2D>()) {
				c.enabled = true;
			}
		}
		foreach (MultiStateAttack a in GetComponentsInChildren<MultiStateAttack>() ) {
			if (a.state != state) {
				a.enabled = false;
				a.weapon.enabled = false;
			} else {
				a.enabled = true;
			}
		}
	}

	public override void Kill ()
	{
		GetComponentInParent<ReubenBoss1> ().advanceState (AdvanceState);
        foreach(BaseEnemy b in GetComponentsInChildren<BaseEnemy>()) {
            if (b.transform != this.transform ) {
                b.Kill();
            }
        }
		base.Kill ();
	}

	public override void OnTriggerEnter2D(Collider2D other) {
				
		Shot shot = other.GetComponent<Shot>();
		
		if (shot != null && !shot.enemyShot) {
			DamageTimeleft = DamageCooldownTime;	
		}

		base.OnTriggerEnter2D (other);
	}

	public override void OnTriggerStay2D(Collider2D other) {
		BeamBlast beam = other.GetComponent<BeamBlast> ();
		if (beam != null && !beam.isEnemy) {
			DamageTimeleft = Time.deltaTime + 0.01f;
		}
		base.OnTriggerStay2D (other);
	}

	public override void OnCollisionEnter2D(Collision2D other) {
		PlayerShip player = other.gameObject.GetComponent<PlayerShip> ();
		if (player != null) {
			DamageTimeleft = DamageCooldownTime;
		} else {
			BaseEnemy enemy = other.gameObject.GetComponent<BaseEnemy> ();
			if (enemy != null && !enemy.collisionImumune) {
				DamageTimeleft = DamageCooldownTime;
			}
		}
		base.OnCollisionEnter2D (other);
	}
}
