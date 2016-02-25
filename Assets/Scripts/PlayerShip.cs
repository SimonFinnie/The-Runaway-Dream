using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {
	

	//The desired components of the players movement.
	private float xDir;
	private float yDir;

	//Current components of the players movement.
	private float xCur = 0;
	private float yCur = 0;

	public string shipName;

	//The max speed of the player.
	public float speed;
	//The rate at which the player can change their direction
	public float handling;

	public int currentWeapon;
	public WeaponType[] weapons;
	public WeaponType primary;
	public float damageReduction;
	WeaponType[] weaponsInst;
	WeaponType primaryInst;
	public float direction;

	

	//Booleans to keep track of wall collision.
	private bool atLeftWall;
	private bool atRightWall;
	private bool atTop;
	private bool atBottom;

	public float HP;
	public float MaxHP;
	public Transform death;


	float coolDownTime = -1.51f;




	public void Begin() {
		HP = MaxHP;
        gameObject.SetActive(true);
		transform.position = new Vector3 (-3f, 0f);
		atLeftWall = false;
		atRightWall = false;
		atTop = false;
		atBottom = false;
		if (weaponsInst != null) {
			foreach (WeaponType w in weaponsInst) {
				if (w != null) {
				Destroy (w.gameObject);
				}
			}
		}
		damageReduction = 1f;
		primaryInst = Instantiate (primary);
		primaryInst.transform.parent = transform;
		primaryInst.transform.localPosition = new Vector3(0.3f, 0f, 0.5f);
		weaponsInst = new WeaponType[weapons.Length];
		for (int i = 0; i < weapons.Length; i++) {
			if (weapons[i] != null){
			weaponsInst [i] = Instantiate (weapons [i]);
				weaponsInst[i].transform.parent = transform;
				if (!weaponsInst[i].centered) {
				weaponsInst[i].transform.localPosition = new Vector3(0.3f, 0f, 0.5f);
				} else {
					weaponsInst[i].transform.localPosition = new Vector3(0f, 0f, -0.5f);
				}
			}
		}

		for (int i = 0; i < GameMaster.level.weaponsDisplay.Length; i ++) {
			if (i < weapons.Length && weapons[i] != null) {
				GameMaster.level.weaponsDisplay[i].weapon = weaponsInst[i];
			} else {
				GameMaster.level.weaponsDisplay[i].gameObject.SetActive(false);
			}
		}
		GameMaster.level.primaryDisplay.weapon = primaryInst;

    }




	
	// Update is called once per frame
	void Update () {

		if (!GameMaster.level.paused) {

			if (Input.GetKey (KeyCode.Slash) && weapons [0] != null && !weapons [0].passive) {
				weaponsInst [0].Activate ();
			} 
			if (Input.GetKey (KeyCode.Period) && weapons.Length > 1 && weapons [1] != null && !weapons [1].passive) {
				weaponsInst [1].Activate ();
			} 
			if (Input.GetKey (KeyCode.Comma) && weapons.Length > 2 && weapons [2] != null && !weapons [2].passive) {
				weaponsInst [2].Activate ();
			}

			if (Input.GetKey (KeyCode.Space)) {
				primaryInst.Activate ();
			}

			//Get user input.
			if (Input.GetKey (KeyCode.W)) {
				if (Input.GetKeyDown (KeyCode.W) || !Input.GetKey (KeyCode.S)) {
					yDir = 1F;
				}
			} else  if (yDir > 0F) {
				yDir = 0F;
			}
			if (Input.GetKey (KeyCode.S)) {
				if (Input.GetKeyDown (KeyCode.S) || !Input.GetKey (KeyCode.W)) {
					yDir = -1F;
				}
			} else  if (yDir < 0F) {
				yDir = 0F;
			}
			if (Input.GetKey (KeyCode.D)) {
				if (Input.GetKeyDown (KeyCode.D) || !Input.GetKey (KeyCode.A)) {
					xDir = 1F;
				}
			} else  if (xDir > 0F) {
				xDir = 0F;
			}
			if (Input.GetKey (KeyCode.A)) {
				if (Input.GetKeyDown (KeyCode.A) || !Input.GetKey (KeyCode.D)) {
					xDir = -1F;
				}
			} else  if (xDir < 0F) {
				xDir = 0F;
			}

		}

		//Correct for vector addition.
		if (xDir != 0F && yDir != 0F) {
			xDir = Mathf.Sin (Mathf.Deg2Rad * 45F) * Mathf.Sign (xDir);
			yDir = Mathf.Sin (Mathf.Deg2Rad * 45F) * Mathf.Sign (yDir);
		} else {
			if (yDir != 0F) {
				yDir = Mathf.Sign(yDir);
			}
			if (xDir != 0F) {
				xDir = Mathf.Sign(xDir);
			}
		}

		//Shoot


		if (HP <= 0) {
            gameObject.SetActive(false);
			Instantiate(death).position = transform.position;
            transform.parent = null;
			GameMaster.level.playerKilled();
		}

		//Apply acceleration.
		if ((xDir - xCur) * Mathf.Sign (xDir - xCur) < handling * Time.deltaTime) {
			xCur = xDir;
		} else {
			xCur += handling * Time.deltaTime * Mathf.Sign (xDir - xCur);
		}
		if ((yDir - yCur) * Mathf.Sign (yDir - yCur) < handling * Time.deltaTime) {
			yCur = yDir;
		} else {
			yCur += handling * Time.deltaTime * Mathf.Sign (yDir - yCur);
		}


		//Zero movement if at wall
		if ((atTop && yCur > 0) || (atBottom && yCur < 0)) {
			yCur = 0;
		}
		if ((atLeftWall && xCur < 0) || (atRightWall && xCur > 0)) {
			xCur = 0;
		}
		
		direction = yCur;



		//Move the player.
		Vector3 movement = Vector3.up * yCur + Vector3.right * xCur;
		transform.Translate (movement * speed * Time.deltaTime);
	
	}

	public void OnTriggerStay2D(Collider2D other) {
		BeamBlast beam = other.GetComponent<BeamBlast> ();
		BeamWall wall = other.GetComponent<BeamWall> ();
		if (beam != null && beam.isEnemy) {
			dealDamage(beam.DPS * Time.deltaTime);
		}
		if (wall != null && (LevelMaster.timeScinceLevelStart - coolDownTime) > 1.5f) {
			coolDownTime = LevelMaster.timeScinceLevelStart;
			dealDamage(wall.bumpingDamage);
		}
	}

	// On collision with a trigger collider...
	void OnTriggerEnter2D(Collider2D other) {
		// Check the tag of the object the player
		// has collided with
		if (other.tag == "LeftWall") {
			atLeftWall = true;
		} else if (other.tag == "RightWall") {
			atRightWall = true;
		} else if (other.tag == "TopWall") {
			atTop = true;
		} else if (other.tag == "BottomWall") {
			atBottom = true;
		}
        Sword sword = other.GetComponent<Sword>();
        SpinSword swordE = other.GetComponent<SpinSword>();
		Shot shot = other.GetComponent<Shot>();
		
		if (shot != null && shot.enemyShot) {
			// Collided with non enemy projectile (so a player projectile)
			dealDamage(shot.damage);
			if(GameMaster.currentScore > shot.points) {
			GameMaster.currentScore -= shot.points;
			}
			// Destroy the projectile game object
			Destroy (other.gameObject);	
		}
        if (sword != null){
            dealDamage(sword.damage);
        }
        if (swordE != null)
        {
            dealDamage(swordE.damage);
        }
    }

	public void dealDamage(float damage){
		HP -= damage * damageReduction;
	}

	void OnTriggerExit2D(Collider2D other) {
		// Check the tag of the object the player
		// has collided with
		if (other.tag == "LeftWall") {
			atLeftWall = false;
		} else if (other.tag == "RightWall") {
			atRightWall = false;
		} else if (other.tag == "TopWall") {
			atTop = false;
		} else if (other.tag == "BottomWall") {
			atBottom = false;
		}
		coolDownTime = -1.51f;
	}
}
