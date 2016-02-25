using UnityEngine;
using System.Collections;

public class TimeWarp : Attack {

	public float liveTime;	
	public float timescale;
	private bool firing = false;
	private float fireTimeLeft = 0;


	public override void FixedUpdate () {
		if (!firing) {
			base.FixedUpdate ();
		} else if (fireTimeLeft >= Time.fixedDeltaTime) {
			fireTimeLeft -= Time.fixedDeltaTime;
			timeSinceLastShot = fireCooldownTime*fireTimeLeft/liveTime;
			if (fireTimeLeft/liveTime < 0.3f) {
				float newTime = (0.3f - fireTimeLeft/liveTime)* (1-timescale)/0.3f + timescale;
				GameMaster.level.trueTime = newTime;
				Time.timeScale = newTime;
			}
		} else {
			fireTimeLeft = 0;
			timeSinceLastShot = 0;
			firing = false;
			
			GameMaster.level.trueTime = 1;
			Time.timeScale = 1;
		}
		
	}
	
	public override void Shoot() {
		// Shoot only if the fire cooldown period
		// has expired
		if(timeSinceLastShot >= fireCooldownTime && !firing) {

			firing = true;
			fireTimeLeft = liveTime;
			GameMaster.level.trueTime = timescale;
			Time.timeScale = timescale;
			
			// Check if shotSound variable has been set...if yes,
			// then play it
			if(shotSound != null) {
				AudioSource.PlayClipAtPoint(shotSound, transform.position);      
			}
		}
	}
}
