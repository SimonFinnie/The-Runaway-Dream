using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

	public float HP;
	public float MaxHP = 20;
	public float touchDamage;
	public float time = 0;
	public float speed;
	public bool hasEntered = false;
	public float orderFactor;
	public bool wrap;
	public bool collisionImumune;
	public int points;
	
	public bool lookAtPlayer;
	protected Vector3 healthbarDrop;

	protected BaseEnemy lastCollision;
	
	public SpriteRenderer healthBar;

	public bool badKill;

	// Use this for initialization
	public virtual void Start () {
		HP = MaxHP;
		if (healthBar != null) {
			healthBar.enabled = false;
			healthbarDrop = healthBar.transform.localPosition;
		}
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		time += Time.deltaTime;

		if (healthBar != null) {
			if (HP < MaxHP) {
				healthBar.enabled = true;
				healthBar.transform.localScale = Vector3.up + Vector3.forward + Vector3.right * HP / MaxHP;
			}
			if (lookAtPlayer) {
				
				float ang = Vector2.Angle (GameMaster.level.player.transform.position - transform.position, Vector3.left);
				if (Vector3.Cross (GameMaster.level.player.transform.position - transform.position, Vector3.left).z > 0) {
					ang = 360 - ang;
				}
				transform.eulerAngles = Vector3.forward * ang;

			}
			if (healthBar.enabled) {
			
			healthBar.transform.position =  healthbarDrop + transform.position;
			healthBar.transform.eulerAngles = new Vector3 (0, 0, 0);
			}
		}
		ValidatePosition ();

		if(HP <= 0) {
			Kill ();
		}
	
	}

	public virtual void ValidatePosition(){
		if (hasEntered) {
			if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
				if (wrap && transform.position.x < 0){
					float offset = GameMaster.level.width + GetComponent<Renderer>().bounds.extents.x + transform.position.x; 
					transform.eulerAngles = new Vector3(0,0,0);
					transform.Translate(Vector3.left * (transform.position.x * 2 + offset));
				} else if (!wrap) {
					Destroy (gameObject);
				}
			}
		} else if (Utility.isVisible(GetComponent<Renderer>(), Camera.main) ){
			hasEntered = true;
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D other) {
		
		
		Shot shot = other.GetComponent<Shot>();
		
		if (shot != null && !shot.enemyShot) {
			// Collided with non enemy projectile (so a player projectile)
			HP -= shot.damage;
			// Destroy the projectile game object
			Destroy (other.gameObject);	
		}
	}

	public virtual void OnTriggerStay2D(Collider2D other) {
		BeamBlast beam = other.GetComponent<BeamBlast> ();
		if (beam != null && !beam.isEnemy) {
			HP -= beam.DPS * Time.deltaTime;
		}
	}

	public virtual void OnCollisionEnter2D(Collision2D other) {
		PlayerShip player = other.gameObject.GetComponent<PlayerShip> ();
		if (player != null){
			player.dealDamage(touchDamage);
			badKill = true;
			Kill ();
			return;
		} 
		BaseEnemy enemy = other.gameObject.GetComponent<BaseEnemy> ();
		if (enemy != null && !enemy.collisionImumune) {
			if (lastCollision == enemy) {
				lastCollision = null;
			} else if (GetComponent<DamageMultiplyer>() == null && enemy.GetComponent<DamageMultiplyer>() == null){
			HP -= 3 *enemy.touchDamage;
			enemy.HP -= 3 * touchDamage;
			if (enemy.HP <= HP){


				enemy.Kill();
			} else {
					;
				Kill();
			}
			} else {
				float multi = 0;
				if (GetComponent<DamageMultiplyer>() != null) {
					multi += GetComponent<DamageMultiplyer>().multiplier;
				}
				if (enemy.GetComponent<DamageMultiplyer>() != null) {
					multi += enemy.GetComponent<DamageMultiplyer>().multiplier;
				}
				HP -= 3 *enemy.touchDamage * multi;
				enemy.HP -= 3 * touchDamage * multi;
				if (enemy.HP <= HP){
					
					
					enemy.Kill();
				} else {
					;
					Kill();
				}
			}
		}
	}

	public virtual void Kill() {
		DestroyScript[] destroytools = GetComponentsInChildren<DestroyScript>();
		for (int i = 0; i < destroytools.Length; i++) {
			destroytools[i].Run();
		}
		if (badKill) {
			if(GameMaster.currentScore >= points){
			GameMaster.currentScore -= points;
			}
		} else {
			GameMaster.currentScore += points;
		}
		Destroy (gameObject);
	}
}
