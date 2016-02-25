using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

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
	
	// How much time is left until able to fire again 
	public float timeSinceLastShot = 0;

	public float speed;

	public float damage;

	public float numberShots;
	
	public bool targeted;
	
	// Per every frame...
	public virtual void Update () {
		// If still some time left until can fire again
		// reduce the time by the time since last
		// frame 
		if (timeSinceLastShot < fireCooldownTime - Time.deltaTime) {
			timeSinceLastShot += Time.deltaTime;
		} else {
			timeSinceLastShot = fireCooldownTime;
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
	
	// Method for firing a projectile
	public virtual void Shoot() {
		float n = 1;
		float shotAngle = numberShots + 2;
		// Shoot only if the fire cooldown period
		// has expired
		if(timeSinceLastShot >= fireCooldownTime) {
			// Create a projectile object from 
			// the shot prefab
			for(int y = 0; y < numberShots;){
				Transform shot;
				EnemyShot shotScript;
				if(numberShots%2 == 0){
					shotAngle = 180/shotAngle;
					shot = Instantiate(shotPrefab);
					shotScript = shot.GetComponent<EnemyShot>();
					shotScript.setUp(speed, damage, (180 + (n*shotAngle)));
					shot.position = transform.position;
					shot.parent = transform.parent.parent;
					shot = Instantiate(shotPrefab);
					shotScript = shot.GetComponent<EnemyShot>();
					shotScript.setUp(speed, damage, (180 + (n*shotAngle)));
					y += 2;
					n++;
				}else{
					shot = Instantiate(shotPrefab);
					shotScript = shot.GetComponent<EnemyShot>();
					shotScript.setUp(speed, damage, 180);
					numberShots--;
				}
				// Set the position of the projectile object
				// to the position of the firing game object
				shot.position = transform.position;
				shot.parent = transform.parent.parent;
				if (targeted) {
					//shot.eulerAngles=Vector3.forward * Vector2.Angle(GameMaster.level.player.transform.position - shot.transform.position, Vector3.right);
					float ang = Vector2.Angle(GameMaster.level.player.transform.position - shot.transform.position, Vector3.left);
					if (Vector3.Cross(GameMaster.level.player.transform.position - shot.transform.position, Vector3.left).z > 0) {
						ang = 360 - ang;
					}
					shot.eulerAngles = Vector3.forward*ang;
				}
			}
			// Set time left until next shot
			// to the cooldown time
			timeSinceLastShot = 0; 
			
			
			// Check if shotSound variable has been set...if yes,
			// then play it
			if(shotSound != null) {
				AudioSource.PlayClipAtPoint(shotSound, transform.position);      
			}
		}
	}
}