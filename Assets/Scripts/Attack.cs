using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	
	// Variable storing projectile object
	// prefab
	public Transform shotPrefab;
	
	// Probability of auto-shoot (0 if
	// no autoshoot)
	public float autoShootProbability;
	
	// Cooldown time for firing
	public float fireCooldownTime;
	
	// Variable storing a reference to an audio clip
	public AudioClip shotSound = null;
	public AudioClip chargeSound = null;
	
	// How much time is left until able to fire again 
	public float timeSinceLastShot = 0;

	public bool targeted;
	public bool charged;
	
	// Per every frame...
	public virtual void FixedUpdate () {
		// If still some time left until can fire again
		// reduce the time by the time since last
		// frame 
		if (timeSinceLastShot < fireCooldownTime - Time.deltaTime) {
			timeSinceLastShot += Time.deltaTime;
		} else {
			timeSinceLastShot = fireCooldownTime;
			if(chargeSound != null && !charged) {
				GameMaster.level.PlaySound(chargeSound,0.8f); 
				charged = true;
			}
		}
		
		// If auto-shoot probability is more than zero...
		if(autoShootProbability > 0) {
			// Generate number a random number between 0 and 1
			float randomSample = Random.Range(0f, 1f);
			// If that random number is less than the 
			// probability of shooting, then try to shoot
			if(randomSample < autoShootProbability) {
				Shoot();   
			}
		}
	}

	public virtual void Start() {
	}
	
	// Method for firing a projectile
	public virtual void Shoot() {
		// Shoot only if the fire cooldown period
		// has expired
		if(timeSinceLastShot >= fireCooldownTime) {
			// Create a projectile object from 
			// the shot prefab
			Transform shot = Instantiate(shotPrefab);
			// Set the position of the projectile object
			// to the position of the firing game object
			shot.position = transform.position;
			shot.rotation = transform.rotation;
			shot.parent = transform.parent.parent;
			if (targeted) {
				//shot.eulerAngles=Vector3.forward * Vector2.Angle(GameMaster.level.player.transform.position - shot.transform.position, Vector3.right);
				float ang = Vector2.Angle(GameMaster.level.player.transform.position - shot.transform.position, Vector3.left);
				if (Vector3.Cross(GameMaster.level.player.transform.position - shot.transform.position, Vector3.left).z > 0) {
					ang = 360 - ang;
				}
				shot.eulerAngles = Vector3.forward*ang;
			}
			// Set time left until next shot
			// to the cooldown time
			timeSinceLastShot = 0; 
			charged = false;

			
			// Check if shotSound variable has been set...if yes,
			// then play it
			if(shotSound != null) {
				GameMaster.level.PlaySound(shotSound, 0.15f);      
			}
		}
	}
}